﻿using System;

namespace hexString {

    /// <summary>
    /// A <see cref="HexString"/> is a convenience type for representing a <see cref="byte"/>
    /// array as a <see cref="string"/>.
    /// </summary>
    public sealed partial class HexString {

        private string _hexadecimalString;
        private byte[] _bytes;

        /// <summary>
        /// Initializes a new <see cref="HexString"/> from a hexadecimal <see cref="string"/>.  
        /// </summary>
        /// <param name="hexadecimalString">The string.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="hexadecimalString"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="hexadecimalString"/> is not a valid HexString.
        /// </exception>
        public HexString(string hexadecimalString) {
            if (hexadecimalString == null) {
                throw new ArgumentNullException("hexadecimalString");
            }
            _bytes = GetBytes(hexadecimalString);
            _hexadecimalString = hexadecimalString.ToLower();
        }

        /// <summary>
        /// Initializes a new <see cref="HexString"/> from a <see cref="byte"/>[]. 
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="bytes"/> is <c>null</c>.
        /// </exception>
        public HexString(byte[] bytes) {
            if (bytes == null) { throw new ArgumentNullException("bytes"); }
            _hexadecimalString = GetString(bytes);
            _bytes = bytes.Clone() as byte[];
        }

        /// <summary>
        /// Gets the bytes represented by the <see cref="HexString"/>. 
        /// </summary>
        /// <returns>A <see cref="byte"/>[].</returns>
        public byte[] ToBytes() {
            return _bytes.Clone() as byte[];
        }

        /// <summary>
        /// Gets the hexadecimal string representation.
        /// </summary>
        /// <returns>The hexadecimal string.</returns>
        public override string ToString() {
            return _hexadecimalString;
        }

        /// <summary>
        /// Casts a <see cref="HexString"/> as a <see cref="string"/>.  
        /// </summary>
        /// <param name="hexString">The <see cref="HexString"/>.</param>
        public static implicit operator string(HexString hexString) {
            return hexString.ToString();
        }

        /// <summary>
        /// Casts a <see cref="HexString"/> as a <see cref="byte"/>[].  
        /// </summary>
        /// <param name="hexString">The <see cref="HexString"/>.</param>
        public static implicit operator byte[](HexString hexString) {
            return hexString.ToBytes();
        }

        /// <summary>
        /// Casts a <see cref="byte"/>[] as a <see cref="HexString"/>.
        /// </summary>
        /// <param name="bytes">The <see cref="byte"/>[].</param>
        public static implicit operator HexString(byte[] bytes) {
            return new HexString(bytes);
        }
    }
}
