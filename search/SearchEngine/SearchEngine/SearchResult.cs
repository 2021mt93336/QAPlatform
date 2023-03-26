using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine
{
	public class SearchResult
	{
		public int id { get; set; }
		public string question { get; set; }
		public float  score { get; set; }
	}
}
