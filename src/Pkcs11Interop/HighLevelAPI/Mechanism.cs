﻿/*
 *  Pkcs11Interop - Open-source .NET wrapper for unmanaged PKCS#11 libraries
 *  Copyright (C) 2012 Jaroslav Imrich <jimrich(at)jimrich(dot)sk>
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License version 3
 *  as published by the Free Software Foundation.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text;
using Net.Pkcs11Interop.Common;

namespace Net.Pkcs11Interop.HighLevelAPI
{
    /// <summary>
    /// Mechanism and its parameters (CK_MECHANISM alternative)
    /// </summary>
    public class Mechanism
    {
        /// <summary>
        /// Low level mechanism structure
        /// </summary>
        private LowLevelAPI.CK_MECHANISM _ckMechanism;

        /// <summary>
        /// Low level mechanism structure
        /// </summary>
        internal LowLevelAPI.CK_MECHANISM CkMechanism
        {
            get
            {
                return _ckMechanism;
            }
        }

        /// <summary>
        /// The type of mechanism
        /// </summary>
        public uint Type
        {
            get
            {
                return _ckMechanism.Mechanism;
            }
        }

        /// <summary>
        /// High level object with mechanism parameters
        /// </summary>
        private IMechanismParams _mechanismParams = null;

        /// <summary>
        /// Creates mechanism of given type with no parameter
        /// </summary>
        /// <param name="type">Mechanism type</param>
        public Mechanism(uint type)
        {
            _ckMechanism = LowLevelAPI.CkmUtils.CreateMechanism(type);
        }

        /// <summary>
        /// Creates mechanism of given type with no parameter
        /// </summary>
        /// <param name="type">Mechanism type</param>
        public Mechanism(CKM type)
        {
            _ckMechanism = LowLevelAPI.CkmUtils.CreateMechanism(type);
        }

        /// <summary>
        /// Creates mechanism of given type with byte array parameter
        /// </summary>
        /// <param name="type">Mechanism type</param>
        /// <param name="parameter">Mechanism parameter</param>
        public Mechanism(uint type, byte[] parameter)
        {
            _ckMechanism = LowLevelAPI.CkmUtils.CreateMechanism(type, parameter);
        }

        /// <summary>
        /// Creates mechanism of given type with byte array parameter
        /// </summary>
        /// <param name="type">Mechanism type</param>
        /// <param name="parameter">Mechanism parameter</param>
        public Mechanism(CKM type, byte[] parameter)
        {
            _ckMechanism = LowLevelAPI.CkmUtils.CreateMechanism(type, parameter);
        }

        /// <summary>
        /// Creates mechanism of given type with object parameter
        /// </summary>
        /// <param name="type">Mechanism type</param>
        /// <param name="parameter">Mechanism parameter</param>
        public Mechanism(uint type, IMechanismParams parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            // Keep reference to parameter => GC will not free parameter while mechanism exists
            _mechanismParams = parameter;

            object lowLevelParams = _mechanismParams.ToLowLevelParams();
            _ckMechanism = LowLevelAPI.CkmUtils.CreateMechanism(type, lowLevelParams);
        }

        /// <summary>
        /// Creates mechanism of given type with object parameter
        /// </summary>
        /// <param name="type">Mechanism type</param>
        /// <param name="parameter">Mechanism parameter</param>
        public Mechanism(CKM type, IMechanismParams parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            // Keep reference to parameter => GC will not free parameter while mechanism exists
            _mechanismParams = parameter;

            object lowLevelParams = _mechanismParams.ToLowLevelParams();
            _ckMechanism = LowLevelAPI.CkmUtils.CreateMechanism(type, lowLevelParams);
        }

        /// <summary>
        /// Class destructor that frees unmanaged memory
        /// </summary>
        ~Mechanism()
        {
            LowLevelAPI.UnmanagedMemory.Free(ref _ckMechanism.Parameter);
            _ckMechanism.ParameterLen = 0;
        }
    }
}