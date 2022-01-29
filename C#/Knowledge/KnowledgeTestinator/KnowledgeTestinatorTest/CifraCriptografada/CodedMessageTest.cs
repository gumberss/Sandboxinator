using FluentAssertions;
using KnowledgeTestinator.CrifraCriptografada;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeTestinatorTest.CifraCriptografada
{
    [TestClass]
    public class CodedMessageTest
    {
        [TestMethod]
        public void Deveria_encontrar_a_mensagem_descriptografada_quando_descriptografar_com_a_cifra()
        {
            String codedMessage = "NNENÃETEMAIOORPC";
            int lines = 3;

            var foundMessage = new CodedMessage().Decode(codedMessage, lines);

            var expected = "NÃOENTREEMPANICO";

            foundMessage.Should().Be(expected);
        }
    }
}
