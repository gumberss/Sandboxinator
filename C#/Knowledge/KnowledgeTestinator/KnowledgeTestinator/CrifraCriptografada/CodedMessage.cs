using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeTestinator.CrifraCriptografada
{
    public class CodedMessage
    {
        public String Decode(String codedMessage, int lines)
        {
            char[] result = new char[codedMessage.Length];

            int row = 0;

            var firstLine = "";

            var column = 0;

            int index = 0;

            int[] flow = new int[lines];
            flow[0] = 0;
            flow[1] = 1;
            for (int i = 2; i < flow.Length; i++)
            {
                flow[i] = flow[i - 1] + 2;
            }

            while (column < codedMessage.Length)
            {
                //first Line
                result[column] = codedMessage[index];
                //0 1 3 5 
                column += (lines - 1) * 2;
                index++;
            }

            return firstLine;
        }
    }
}
