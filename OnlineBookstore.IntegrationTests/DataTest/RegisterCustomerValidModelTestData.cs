using OnlineBookstore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.IntegrationTests.DataTest
{
    public class RegisterCustomerValidModelTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var list = new List<RegisterCustomerDTO>()
            {
                new RegisterCustomerDTO()
                {
                        Email = "test@test.com",
                        Password = "123456",
                        ConfirmPassword = "123456",
                        RoleId = 1,
                        DateOfBirth = DateTime.Now,
                        Phone="88888888",
                        LastName="Stones",
                        FisrtName="John"
                },
                new RegisterCustomerDTO()
                {
                        Email = "test2@test.com",
                        Password = "haslo1234",
                        ConfirmPassword = "haslo1234",
                        RoleId = 1,
                        DateOfBirth = new DateTime(1997,5,20),
                        Phone="88888888",
                        LastName="Track",
                        FisrtName="Cris"
                }
            };
            foreach (var item in list)  yield return new object[] { item };
        }

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
       
    }
}


