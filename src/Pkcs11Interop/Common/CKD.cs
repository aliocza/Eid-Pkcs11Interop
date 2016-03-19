﻿/*
 *  Copyright 2012-2016 The Pkcs11Interop Project
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

/*
 *  Written for the Pkcs11Interop project by:
 *  Jaroslav IMRICH <jimrich@jimrich.sk>
 */

namespace Net.Pkcs11Interop.Common
{
    /// <summary>
    /// Key derivation functions
    /// </summary>
    public enum CKD : uint
    {
        /// <summary>
        /// Produces a raw shared secret value without applying any key derivation function
        /// </summary>
        CKD_NULL = 0x00000001,

        /// <summary>
        /// Derives keying data from the shared secret value as defined in ANSI X9.63
        /// </summary>
        CKD_SHA1_KDF = 0x00000002,

        /// <summary>
        /// Derives keying data from the shared secret value as defined in the ANSI X9.42 standard
        /// </summary>
        CKD_SHA1_KDF_ASN1 = 0x00000003,

        /// <summary>
        /// Derives keying data from the shared secret value as defined in the ANSI X9.42 standard
        /// </summary>
        CKD_SHA1_KDF_CONCATENATE = 0x00000004
    }
}
