﻿// Copyright (c) Stanislav Kuzmich.  All Rights Reserved.
// Licensed under the Microsoft Public License (MS-PL).
// See License.txt in the project for license information.

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace ASD.ESH.Classification {

    [Export(typeof(IClassifierProvider))]
    [ContentType("CSharp"), ContentType("Basic")]
    internal sealed class ClassifierProvider : IClassifierProvider {

#pragma warning disable CS0649
        [Import] private IClassificationTypeRegistryService registryService; // set via MEF
#pragma warning restore CS0649

        IClassifier IClassifierProvider.GetClassifier(ITextBuffer textBuffer) {

            if (!TypesRegistry.Initialized) {
                TypesRegistry.Initialize(registryService);
            }
            return new Classifier();
        }
    }
}