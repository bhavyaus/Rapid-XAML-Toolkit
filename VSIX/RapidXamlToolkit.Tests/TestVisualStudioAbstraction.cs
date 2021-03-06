﻿// Copyright (c) Matt Lacey Ltd. All rights reserved.
// Licensed under the MIT license.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using RapidXamlToolkit.Commands;
using RapidXamlToolkit.VisualStudioIntegration;

namespace RapidXamlToolkit.Tests
{
    public class TestVisualStudioAbstraction : IVisualStudioAbstraction
    {
        public ProjectWrapper ActiveProject { get; set; } = null;

        public ProjectWrapper NamedProject { get; set; } = null;

        public SyntaxTree SyntaxTree { get; set; } = null;

        public SemanticModel SemanticModel { get; set; } = null;

        public bool UserConfirmsResult { get; set; } = false;

        public string ActiveDocumentFileName { get; set; }

        public string ActiveDocumentText { get; set; }

        public bool DocumentIsCSharp { get; set; } = false;

        public int CursorPosition { get; set; } = -1;

        public int LineNumber { get; set; } = 1;  // Assume that everything is on one line for testing. Bypasses the way VS adds extra char for end of line

        public int XamlIndent { get; set; } = 4;

        public ProjectWrapper GetActiveProject()
        {
            return this.ActiveProject;
        }

        public ProjectWrapper GetProject(string projectName)
        {
            return this.NamedProject;
        }

        public virtual async Task<(SyntaxTree syntaxTree, SemanticModel semModel)> GetDocumentModelsAsync(string fileName)
        {
            await Task.CompletedTask;
            return (this.SyntaxTree, this.SemanticModel);
        }

        public bool UserConfirms(string title, string message)
        {
            return this.UserConfirmsResult;
        }

        public string GetActiveDocumentFileName()
        {
            return this.ActiveDocumentFileName;
        }

        public string GetActiveDocumentText()
        {
            return this.ActiveDocumentText;
        }

        public async Task<(SyntaxTree syntaxTree, SemanticModel semModel)> GetDocumentModelsAsync(Document document)
        {
            await Task.CompletedTask;
            return (this.SyntaxTree, this.SemanticModel);
        }

        public bool ActiveDocumentIsCSharp()
        {
            return this.DocumentIsCSharp;
        }

        public int GetCursorPosition()
        {
            return this.CursorPosition;
        }

        public (int, int) GetCursorPositionAndLineNumber()
        {
            return (this.CursorPosition, this.LineNumber);
        }

        public void ReplaceInActiveDocOnLine(string find, string replace, int lineNumber)
        {
            // NOOP
        }

        public void ReplaceInActiveDoc(string find, string replace, int startIndex, int endIndex)
        {
            // NOOP
        }

        public void ReplaceInActiveDoc(List<(string find, string replace)> replacements, int startIndex, int endIndex, Dictionary<int, int> exclusion)
        {
            // NOOP
        }

        public void InsertIntoActiveDocumentOnNextLine(string text, int pos)
        {
            // NOOP
        }

        public void InsertAtEndOfLine(int lineNumber, string toInsert)
        {
            // NOOP
        }

        public void DeleteFromEndOfLine(int lineNumber, int charsToDelete)
        {
            // NOOP
        }

        public bool StartSingleUndoOperation(string name)
        {
            return true;
        }

        public void EndSingleUndoOperation()
        {
            // NOOP
        }

        public async Task<int> GetXamlIndentAsync()
        {
            await Task.CompletedTask;
            return this.XamlIndent;
        }

        public void ReplaceInActiveDocOnLineOrAbove(string find, string replace, int lineNumber)
        {
            // NOOP
        }

        public void RemoveInActiveDocOnLine(string find, int lineNumber)
        {
            // NOOP
        }

        public ProjectType GetProjectType(EnvDTE.Project project)
        {
            return ProjectType.Unknown;
        }

        public void InsertIntoActiveDocOnLineAfterClosingTag(int openingAngleBracketLineNumber, string toInsert)
        {
            // NOOP
        }
    }
}
