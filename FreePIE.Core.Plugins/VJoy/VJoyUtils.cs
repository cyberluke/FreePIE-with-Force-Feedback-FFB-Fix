﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJoyInterfaceWrap;

namespace FreePIE.Core.Plugins.VJoy
{
    class VJoyUtils
    {
        public static readonly vJoy Joystick = new vJoy();

        // Polar values (0x00-0xFF) to Degrees (0-360)
        public static int Polar2Deg(UInt16 Polar)
        {
            return (int)((long)Polar * 360) / 32767;
        }

        // Convert range 0x00-0xFF to 0%-100%
        public static int Byte2Percent(byte InByte)
        {
            return ((byte)InByte * 100) / 255;
        }

        // Convert Effect type to String
        public static bool EffectType2Str(FFBEType Type, out string Str)
        {
            bool stat = true;
            Str = "";

            switch (Type)
            {
                case FFBEType.ET_NONE:
                    stat = false;
                    break;
                case FFBEType.ET_CONST:
                    Str = "Constant Force";
                    break;
                case FFBEType.ET_RAMP:
                    Str = "Ramp";
                    break;
                case FFBEType.ET_SQR:
                    Str = "Square";
                    break;
                case FFBEType.ET_SINE:
                    Str = "Sine";
                    break;
                case FFBEType.ET_TRNGL:
                    Str = "Triangle";
                    break;
                case FFBEType.ET_STUP:
                    Str = "Sawtooth Up";
                    break;
                case FFBEType.ET_STDN:
                    Str = "Sawtooth Down";
                    break;
                case FFBEType.ET_SPRNG:
                    Str = "Spring";
                    break;
                case FFBEType.ET_DMPR:
                    Str = "Damper";
                    break;
                case FFBEType.ET_INRT:
                    Str = "Inertia";
                    break;
                case FFBEType.ET_FRCTN:
                    Str = "Friction";
                    break;
                case FFBEType.ET_CSTM:
                    Str = "Custom Force";
                    break;
                default:
                    stat = false;
                    break;
            }

            return stat;
        }

        /// <summary>Returns the highest value encountered in an enumeration (.NET 2.0 COMPATIBLE)</summary>
        /// <typeparam name="EnumType">
        ///   Enumeration of which the highest value will be returned
        /// </typeparam>
        /// <returns>The highest value in the enumeration</returns>
        public static EnumType highestValueInEnum<EnumType>() where EnumType : IComparable
        {
            EnumType[] values = (EnumType[])Enum.GetValues(typeof(EnumType));
            EnumType highestValue = values[0];
            for (int index = 0; index < values.Length; ++index)
            {
                if (values[index].CompareTo(highestValue) > 0)
                {
                    highestValue = values[index];
                }
            }

            return highestValue;
        }

        const string Separator = ", ";

        public static string FlagsEnumToString<T>(Enum e)
        {
            var str = new StringBuilder();

            foreach (object i in Enum.GetValues(typeof(T)))
            {
                if (IsExactlyOneBitSet((int)i) &&
                    e.HasFlag((Enum)i))
                {
                    str.Append((T)i + Separator);
                }
            }

            if (str.Length > 0)
            {
                str.Length -= Separator.Length;
            }

            return str.ToString();
        }

        static bool IsExactlyOneBitSet(int i)
        {
            return i != 0 && (i & (i - 1)) == 0;
        }
    }
}
