﻿using Micros.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Micros.Application.Services
{
    public class HashService : IHashService
    {
        public string GetHash(string key)
        {
            var sha256 = new SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(key);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
