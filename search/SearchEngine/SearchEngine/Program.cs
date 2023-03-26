using System;
using System.Collections.Generic;

namespace SearchEngine
{
	class Program
	{
		[Obsolete]
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			LuceneSearch search = new LuceneSearch();

			List<SearchResult> questions = SQLUtil.GetQuestions();

			foreach(var question in questions)
			{
				search.AddIndex(question.id, question.question);
			}

			List<SearchResult> results = search.GetSearchResults("test");

			foreach(var result in results)
			{
				Console.WriteLine($"{result.id} {result.question}");
			}

		}
	}
}
