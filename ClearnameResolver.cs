using System.Collections.Generic;

namespace JPPSVN {
   public class ClearnameResolver {
	   private readonly Dictionary<string, List<string>> nameToId, idToName;
		public static readonly ClearnameResolver EMPTY = new ClearnameResolver(new Dictionary<string, List<string>>(), new Dictionary<string, List<string>>());

      public ClearnameResolver(Dictionary<string, List<string>> nameToId, Dictionary<string, List<string>> idToName) {
         this.nameToId = nameToId;
         this.idToName = idToName;
      }

      public bool ResolveID(string name, out List<string> res) {
		   return nameToId.TryGetValue(name, out res);
	   }

	   public bool ResolveName(string id, out List<string> res) {
		   return idToName.TryGetValue(id, out res);
	   }


	   private static void InsertOrAppend<TKey, TValue>(Dictionary<TKey, List<TValue>> dictionary, TKey key, TValue value) {
		   if (dictionary.TryGetValue(key, out var list)) {
			   list.Add(value);
		   } else {
			   list = new List<TValue> { value };
			   dictionary.Add(key, list);
		   }
      }

      public static ClearnameResolver FromExternals(string property) {
	      Dictionary<string, List<string>> nameToId = new Dictionary<string, List<string>>(),
		      idToName = new Dictionary<string, List<string>>();

		   for (int i = 0; i < property.Length; ++i) {
			   while (property[i] != '"') {
				   ++i;
				   if (!(i < property.Length))
					   goto end;
			   }

			   int i1 = i;
			   ++i;
			   if (!(i < property.Length))
				   goto end;

			   while (property[i] != '"') {
				   ++i;
				   if (!(i < property.Length))
					   goto end;
			   }

			   int i2 = i;

			   int j;
			   for (j = i2; j > i1; --j) {
				   if (property[j] == '-')
					   break;
			   }

			   if (j != i1) {
				   string fullName = property.Substring(i1 + 1, j - 1 - (i1 + 1));
				   string sn = property.Substring(j + 2, i2 - 1 - (j + 1));

				   InsertOrAppend(nameToId, fullName, sn);
				   InsertOrAppend(idToName, sn, fullName);
			   }
		   }
		   end:
		   return new ClearnameResolver(nameToId, idToName);
	   }
   }
}
