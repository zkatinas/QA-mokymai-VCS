﻿using NUnit.Framework;
using QA_Mokymai_VCS_Pamoka_0409.API;
using QA_Mokymai_VCS_Pamoka_0409.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.Tests
{
    public class TestApi1
    {
        [Test]
        public void Test1()
        {
            LoginAPI.Login(User.DefaultKikaUser);
        }
    }
}
