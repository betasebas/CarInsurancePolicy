using System;
using CarInsurancePolicyDomain.Entities;

namespace CarInsurancePolicyDomain.Helpers
{
    public static class UserHelper
    {
        public static List<User> Users = new()
            {
                    new User(){ UserName="sebas",Password="test", Role="Admin"}
            };
    }
}

