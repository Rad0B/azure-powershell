﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Create Vault Secret Group object
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        ProfileNouns.VaultSecretGroup),
    OutputType(
        typeof(VaultSecretGroup))]
    public class NewAzureVaultSecretGroupCommand : AzurePSCmdlet
    {
        [Parameter(
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Certificate store in LocalMachine")]
        [ValidateNotNullOrEmpty]
        public string ReferenceUri { get; set; }

        [Parameter(
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "URL referencing a secret in a Key Vault.")]
        [ValidateNotNullOrEmpty]
        public List<VaultCertificate> VaultCertificates { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(new VaultSecretGroup
            {
                SourceVault = new SourceVaultReference { ReferenceUri = this.ReferenceUri },
                VaultCertificates = this.VaultCertificates,
            });
        }
    }
}
