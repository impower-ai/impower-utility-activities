﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impower.Queue.Activities.Utilities
{
    public static class Util
    {
        public static Dictionary<String, T> ConvertedDictionary<T>(Dictionary<String, Object> specificContent)
        {
            if (specificContent == null) return null;
            var RunningDictionary = new Dictionary<String, T>();
            foreach (KeyValuePair<String, Object> pair in specificContent)
            {
                Console.WriteLine(typeof(T));
                if (pair.Value == null) continue;

                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.Int32:
                        if (Int32.TryParse(pair.Value.ToString(), out var parsed))
                        {
                            RunningDictionary.Add(pair.Key, (T)(object)parsed);
                        }
                        break;
                    case TypeCode.String:
                        if (String.IsNullOrEmpty(pair.Value.ToString())) { continue; }
                        RunningDictionary.Add(pair.Key, (T)(object)pair.Value.ToString());
                        break;
                    default:
                        Console.WriteLine("Mega angy");
                        break;
                }
            }
            return RunningDictionary;
        }
    }
}