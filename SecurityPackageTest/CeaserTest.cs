﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityLibrary;

namespace SecurityPackageTest
{
    [TestClass]
    public class CeaserTest
    {
        string mainPlain = "meetmeaftertheparty";
        string mainCipher = "phhwphdiwhuwkhsduwb".ToUpper();
        int mainKey = 3;

        string mainPlain1 = "defendtheeastwallofthecastle";
        string mainCipher1 = "defendtheeastwallofthecastle".ToUpper();
        int mainKey1 = 0;

        string mainPlain2 = "defendtheeastwallofthecastle";
        string mainCipher2 = "bcdclbrfccyqruyjjmdrfcayqrjc".ToUpper();
        int mainKey2 = 24;

        [TestMethod]
        public void CeaserTestEnc1()
        {
            Ceaser algorithm = new Ceaser();
            string cipher = algorithm.Encrypt(mainPlain, mainKey);
            Assert.IsTrue(cipher.Equals(mainCipher, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void CeaserTestDec1()
        {
            Ceaser algorithm = new Ceaser();
            string plain = algorithm.Decrypt(mainCipher, mainKey);
            Assert.IsTrue(plain.Equals(mainPlain, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void CeaserTestAnalysis1()
        {
            Ceaser algorithm = new Ceaser();
            int key = algorithm.Analyse(mainPlain, mainCipher);
            Assert.AreEqual(mainKey, key);
        }

        [TestMethod]
        public void CeaserTestEnc2()
        {
            Ceaser algorithm = new Ceaser();
            string cipher = algorithm.Encrypt(mainPlain1, mainKey1);
            Assert.IsTrue(cipher.Equals(mainCipher1, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void CeaserTestDec2()
        {
            Ceaser algorithm = new Ceaser();
            string plain = algorithm.Decrypt(mainCipher1, mainKey1);
            Assert.IsTrue(plain.Equals(mainPlain1, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void CeaserTestAnalysis2()
        {
            Ceaser algorithm = new Ceaser();
            int key = algorithm.Analyse(mainPlain1, mainCipher1);
            Assert.AreEqual(mainKey1, key);
        }

        [TestMethod]
        public void CeaserTestEnc3()
        {
            Ceaser algorithm = new Ceaser();
            string cipher = algorithm.Encrypt(mainPlain2, mainKey2);
            Assert.IsTrue(cipher.Equals(mainCipher2, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void CeaserTestDec3()
        {
            Ceaser algorithm = new Ceaser();
            string plain = algorithm.Decrypt(mainCipher2, mainKey2);
            Assert.IsTrue(plain.Equals(mainPlain2, StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void CeaserTestAnalysis3()
        {
            Ceaser algorithm = new Ceaser();
            int key = algorithm.Analyse(mainPlain2, mainCipher2);
            Assert.AreEqual(mainKey2, key);
        }

    }
}
