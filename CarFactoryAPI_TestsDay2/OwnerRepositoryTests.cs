using CarAPI.Entities;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryAPI_TestsDay2
{
    public class OwnerRepositoryTests
    {
        //mock dependencies
        Mock<FactoryContext> mockFactoryContext;

        //use fake object
        OwnerRepository ownerRepository;
        public OwnerRepositoryTests() 
        {
            //mock dependencies
            mockFactoryContext = new();
            //use fake object 
            ownerRepository = new(mockFactoryContext.Object);
        }

        [Fact]
        [Trait("About", "OwnerRepository")]
        public void GetAllOwners_AskForOwners_listOfOwners()
        {
            //arrange
            //bulid mock data
            List<Owner> owners = new List<Owner>()
            {
                new Owner(){  Id = 1 ,Name="islam"},
                new Owner(){  Id = 10 ,Name="amin"},
                new Owner(){  Id = 100 ,Name="rahaf"}
            };
            //setup called Dbsets
            mockFactoryContext.Setup(o => o.Owners).ReturnsDbSet(owners);

            //act
            var result=ownerRepository.GetAllOwners();
            //assets
            Assert.NotEmpty(result);

        }
        [Fact]
        [Trait("About", "OwnerRepository")]
        public void AddOwner_AddingOwner_true()
        {
            //arrange
            //build mock data
            List<Owner> owners = new List<Owner>()
            {
                new Owner(){  Id = 2 ,Name="islam"},
                new Owner(){  Id = 10 ,Name="amin"},
                new Owner(){  Id = 100 ,Name="rahaf"}
            };
            Owner owner = new Owner() { Id = 1, Name = "islam" };
            //setup called Dbsets
            mockFactoryContext.Setup(o => o.Owners).ReturnsDbSet(owners);

            //act
            var result = ownerRepository.AddOwner(owner);
            //assets
            Assert.True(result);

        }
       [Fact(Skip ="understanding DPset in Mock")]
       // [Fact]
        [Trait("About", "OwnerRepository")]
        public void AddOwner_NotAddingOwnerAlreadyExit_False ()
        {
            //arrange
            //build mock data
            List<Owner> owners = new List<Owner>()
            {
                new Owner(){  Id = 1 ,Name="islam"},
                new Owner(){  Id = 10 ,Name="amin"},
                new Owner(){  Id = 100 ,Name="rahaf"}
            };
            Owner owner = new Owner() { Id = 1, Name = "islam" };
            //setup called Dbsets
            mockFactoryContext.Setup(o => o.Owners).ReturnsDbSet(owners);

            //act
            var result = ownerRepository.AddOwner(owner);
            //assets
            //Assert.False(result);
            Assert.Equal(4, mockFactoryContext.Object.Owners.Count());
        }






    }
}
