using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Program root = new Program();

            root.BasicOperator();
        }

        public void BasicOperator()
        {
            // Reference : Query Expression Basics, https://msdn.microsoft.com/en-us/library/bb384065.aspx1
            /*
             * Visual Studio包括LINQY組件，其使用於.NET框架的倉儲元件(Collections)，SQL資料庫伺服，ADO.NET資料集，XML文件。
             * 傳統上，針對不同資料系統其Query格式並不相同，對此Visual Studio於2008後提供LINQ，讓開發者可以用統一的格式對XML文件、資料庫、繼承IEnumerable物件進行詢問。
             * 
             * Reference : Data Transformations with LINQ, https://msdn.microsoft.com/en-us/library/bb397914.aspx
             * 從應用觀點來看，資料源頭的結構與型態並不重要，在程式內資料源都是由IEnumerable<T>或IQueryable<T>收藏著。
             * LINQ用於XML文件，資料型態為IEnumerable<XElement>。
             * LINQ用於資料集，資料型態為IEnumerable<DataRow>。
             * LINQ用於SQL，資料型態為使用者定義於SQL資料庫溝通的自定物件，但仍收藏於IEnumerable<T>或IQueryable<T>。
             * 
             * LINQ運算式定義時並不會被執行。
             * 句型：[Query variable] = [Required][Optional]...[Optional][End]
             * 定義：[IEnumerable<T> expression-name] = [form variable in source-collections][where lambda-expression]...[orderby optional][select or group optional]
             * 
             * LINQ執行是當IEnumerable<T>的方法被執行時，才會運作設定的運算式；而一般的操作設定由foreach陳述式啟動，因為陳述式會運行IEnumerator.MoveNext。
             * 
             * Reference : Query Syntax and Method Syntax in LINQ, https://msdn.microsoft.com/en-us/library/bb397947.aspx
             * LINQ定義運算式可由查詢語法(Query Syntax)或方法語法(Method Syntax)來執行，方法語法可看成物件提供的方法中，在補充Lambda運算式後自動產生的查詢語法，因此能產出的結果受限與物件本身，但若只是簡單式可以此運作。
             */
            Console.WriteLine("Basic Operator : ");

            // Specify the data source.
            int[] scores = new int[] { 97, 92, 81, 60, 50, 99 };

            // Query syntax
            // Define the query expression.
            // In here, LINQ didn't execute.
            // Reference : Type Relationships in LINQ Query Operations, https://msdn.microsoft.com/en-us/library/bb397924.aspx
            // Reference : Basic LINQ Query Operations, https://msdn.microsoft.com/en-us/library/bb397927.aspx
            /* 語法：
             * 
             * from clause, https://msdn.microsoft.com/en-us/library/bb383978.aspx
             * form用於指定資料源內容於LINQ內的變數稱呼，其型態對應於資料源本身型態。
             * form一句定義一個變數，若要定義多個變數，則需撰寫多行form。
             * 
             * group clause, https://msdn.microsoft.com/en-us/library/bb384063.aspx
             * group用於將執行結果輸出，其輸出會依據定義之Key存放於group中，使其成為一個Hash-Table。
             * e.g : group student by student.Last[0] into g
             * 將student資料放入Key=student.Last[0]的group中，其group名稱為g；注意，使用into設定group辨識名，表示後續仍由運算式，若無則應不填寫。
             * 
             * select clause, https://msdn.microsoft.com/en-us/library/bb384087.aspx
             * select用於將執行結果輸出，其輸出會是IEnumerable<T>的一維陣列；注意，select可以使用into設定辨識名，但這表示後續仍由運算式，若無則應不填寫。
             * e.g : IEnumerable<int> queryScores = ... select score;
             * 將結果輸出為名為queryScores的列舉物件，型態為int，內容來自score。
             * e.g : var list = ... select new { student.First, student.Last };
             * 將結果輸出為無名列舉物件，型態為Object，內容為Object.First = student.First，Object.Last = student.Last。
             * e.g : var list = ... select new { A = student.First, B = student.Last };
             * 將結果輸出為無名列舉物件，型態為Object，內容為Object.A = student.First，Object.B = student.Last。
             * e.g : IEnumerable<S> list = ... select new S { A = x.b, B = x.a};
             * 將結果輸出為名為list的列舉物件，型態為S，內容為S.A = x.b，S.B = x.a。
             * 
             * optional clause : where, join, orderby, from, let，這些操作可能存在零到很多句於單一LINQ運算式。
             * where Clause : 過濾條件式。
             * orderby Clause : 輸出結果排序條件式。
             * join Clause, https://msdn.microsoft.com/en-us/library/bb311040.aspx :
             * 用於合併不同資料源，當其條件式成立，輸出合併後的物件。
             * let Clause, https://msdn.microsoft.com/en-us/library/bb383976.aspx :
             * 用於運算式執行時，依當下狀況動態產生矩陣變數(Range variable)，並以此為資料源或條件式參數。
             */
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Method-based syntax
            IEnumerable<int> scoreQueryMethod = scores.Where(s => s > 80);

            // Execute the query.
            Console.WriteLine("Query syntax >> ");
            foreach( int i in scoreQuery )
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // Execute the query.
            Console.WriteLine("Method-based syntax >> ");
            foreach (int i in scoreQueryMethod)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
