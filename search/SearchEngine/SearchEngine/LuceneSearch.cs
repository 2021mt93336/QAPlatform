using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine
{
	public class LuceneSearch
	{
		// Ensures index backward compatibility
		const Lucene.Net.Util.Version AppLuceneVersion = Lucene.Net.Util.Version.LUCENE_30;
		private Analyzer analyzer = new StandardAnalyzer(AppLuceneVersion);
		private Directory luceneIndexDirectory;
		private IndexWriter writer;
		private string indexPath = @"c:\temp\LuceneIndex";

		public LuceneSearch()
		{
			InitialiseLucene();
		}

		private void InitialiseLucene()
		{
			if (System.IO.Directory.Exists(indexPath))
			{
				System.IO.Directory.Delete(indexPath, true);
			}

			luceneIndexDirectory = FSDirectory.Open(indexPath);
			writer = new IndexWriter(luceneIndexDirectory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
		}

		public void AddIndex(int id, string question)
		{
			Document doc = new Document();
			doc.Add(new Field("Id",id.ToString(),Field.Store.YES, Field.Index.NO));
			doc.Add(new Field("Question",question,Field.Store.YES,Field.Index.ANALYZED));
			writer.AddDocument(doc);
		}

		[Obsolete]
		private void BuildIndex()
		{
			writer.Optimize();
			writer.Flush(triggerMerge: false, flushDocStores: false, flushDeletes: false);
			writer.Close();
			//luceneIndexDirectory.Close();
		}

		[Obsolete]
		public List<SearchResult> GetSearchResults(string searchTerm)
		{
			BuildIndex();
			IndexSearcher searcher = new IndexSearcher(luceneIndexDirectory);
			QueryParser parser = new QueryParser(AppLuceneVersion, "Question", analyzer);

			Query query = parser.Parse(searchTerm);
			var hitsFound = searcher.Search(query,20).ScoreDocs;
			List<SearchResult> results = new List<SearchResult>();
			SearchResult result = null;

			foreach (var hit in hitsFound)
			{
				result = new SearchResult();
				Document doc = searcher.Doc(hit.Doc);
				result.id = int.Parse(doc.Get("Id"));
				result.question = doc.Get("Question");
				results.Add(result);
			}

			return results;
		}
		/*
		
		public List<SearchResult> GetSearchResults(string searchTerm)
		{
			// Ensures index backward compatibility
			const Lucene.Net.Util.Version AppLuceneVersion = Lucene.Net.Util.Version.LUCENE_30;

			// Construct a machine-independent path for the index
			//var basePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			var basePath = @"C:\Users\abdulkalamaz\Desktop";
			var indexPath = Path.Combine(basePath, "index");

			using var dir = FSDirectory.Open(indexPath);
			//dir.EnsureOpen();
			// Create an analyzer to proces the text
			var analyzer = new StandardAnalyzer(AppLuceneVersion);

			// Create an index writer
			var writer = new IndexWriter(dir, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);

			var phrase = BreakdownSearchTerm(searchTerm);

			List<SearchResult> results = new List<SearchResult>();

			// Re-use the writer to get real-time updates
			using var reader = writer.GetReader();
			var searcher = new IndexSearcher(reader);
			var hits = searcher.Search(phrase, 20 ).ScoreDocs;

			// Display the output in a table
			Console.WriteLine($"{"Score",10}" +
				$" {"Name",-15}" +
				$" {"Favorite Phrase",-40}");

			foreach (var hit in hits)
			{
				var foundDoc = searcher.Doc(hit.Doc);
				Console.WriteLine($"{hit.Score:f8}" +
					$" {foundDoc.Get("Id"),-15}" +
					$" {foundDoc.Get("favoritePhrase"),-40}");

				var result = new SearchResult()
				{
					id = int.Parse(foundDoc.Get("Id")),
					question = foundDoc.Get("favoritePhrase")
				};
				results.Add(result);
			}

			return results;
		}

		public MultiPhraseQuery BreakdownSearchTerm(string searchTerm)
		{
			// Search with a phrase
			var phrase = new MultiPhraseQuery();
			phrase.Add(new Term("favoritePhrase", searchTerm));

			return phrase;
		}
		*/
	}
}
