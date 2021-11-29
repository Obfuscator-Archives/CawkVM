﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Injection
{
    class InjectMethods
    {
        public static void methodInjector()
        {
            int pos = 0;
            foreach (Protection.MethodData methodData in Protection.MethodProccesor.AllMethods)
            {
                methodData.position = pos;
                var cipherLen = (methodData.DecryptedBytes.Length / 16 + 1) * 16;
                methodData.cipherSize = cipherLen;
                Console.WriteLine("injecting");
                Injection.InjectInitialise.InjectMethod(methodData.Method, methodData.position, methodData.ID, methodData.cipherSize);


                pos += cipherLen;

            }
        }
    }
}
