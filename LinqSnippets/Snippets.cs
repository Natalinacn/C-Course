using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace LinqSnippets
{
    public class Snippets
    {

        static public void BasicLinQ()
        {

            string[] cars = {
            "VW Golf",
            "VW California",
            "Audi A3",
            "Audi A5",
            "Fiat Punto",
            "Seat Ibiza",
            "Seat León",

            };

            //1. SELECT * of cars (SELECT ALL CARS)

            var carList = from car in cars select car; //Esto devuelve una lista que luego podemos iterar

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            //2. SELECT WHERE car is Audi (SELECT AUDIs)

            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }

        }

        //Number Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Each number multiplied by 3
            //Take all numbers, but 9
            //Order ascending

            var processedNumberList =
                numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);

        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string> {
            "a",
            "bx",
            "c",
            "d",
            "e",
            "cj",
            "f",
            "c"
            };

            //First of all alements
            var first = textList.First();

            //First element that is "c"
            var cText = textList.First(text => text.Equals("c")); //Nos devuelve el primero
            var cTextAll = textList.All(text => text.Equals("c")); //Nos devuelve todos

            //First element that contains "j"

            var jText = textList.First(text => text.Contains("j"));

            //First element that contains z or default. Devuelve el primero o un elemento por defecto que puede ser un elemento vacio "", una lista vacía, un 0, una cadena vacía
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            //Last element that contains z or default
            var lastOrDefault = textList.LastOrDefault(text => text.Contains("z"));

            //Single values
            var uniqueText = textList.Single();
            var uniqueOrDefaultText = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            //Obtain { 4, 8 }
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); //Esto devuelve 4 y 8 ya que los elementos repetidos entre las listas no los trae


        }

        static public void MultipleSelects()
        {
            //Select Many
            string[] myOpinions = {
            "Opinion 1, text 1",
            "Opinion 2, text 2",
            "Opinion 3, text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));
            var enterprises = new[]
            {
                new Enterprise()
                {
                Id=1,
                Name = "Enterprise 1",
                Employees = new []
                {
                    new Employee{
                    Id =1,
                    Name="Martin",
                    Email="mar@gmail",
                    Salary= 3000
                    },
                    new Employee{
                    Id =2,
                    Name="pepe",
                    Email="pepe@gmail",
                    Salary= 1000
                    },
                    new Employee{
                    Id =3,
                    Name="Pedro",
                    Email="pedro@gmail",
                    Salary= 2000
                    }

                }
                },
                new Enterprise()
                {
                Id=2,
                Name = "Enterprise 2",
                Employees = new []
                {
                    new Employee{
                    Id =4,
                    Name="Carla",
                    Email="carla@gmail",
                    Salary= 3000
                    },
                    new Employee{
                    Id =5,
                    Name="Alfred",
                    Email="alf@gmail",
                    Salary= 1000
                    },
                    new Employee{
                    Id =6,
                    Name="Carina",
                    Email="cari@gmail",
                    Salary= 2000
                    }

                }
                },
                new Enterprise()
                {
                Id=3,
                Name = "Enterprise 3",
                Employees = new []
                {
                    new Employee{
                    Id =7,
                    Name="marcos",
                    Email="marcos@gmail",
                    Salary= 3700
                    },
                    new Employee{
                    Id =8,
                    Name="Liam",
                    Email="liam@gmail",
                    Salary= 1500
                    },
                    new Employee{
                    Id =9,
                    Name="Naty",
                    Email="nat@gmail",
                    Salary= 2400
                    }

                }
                }
            };

            //Obtain all Employees of all Enterprises

            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);
            //Know if any list is empty
            bool hastEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            //All enterprises at least has an employee with more than 1000 euros salary
            bool hasEmployeeWithSalaryMoreThan1000 =
                enterprises.Any(enterprise =>
                enterprise.Employees.Any(employee => employee.Salary > 1000));
        }

        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            //Inner Join

            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                secondList,
                elementt => elementt,
                secondElement => secondElement,
                (element, secondElement) => new { element, secondElement }
                );

            //OUTER Join = LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };


            //OUTER Join = RIGHT
            var rightOuterJoin = from secondElement in secondList
                                 join element in firstList
                                on secondElement equals element
                                into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where secondElement != temporalElement
                                 select new { Element = secondElement };

            //Union: Agarro todos los elementos que no se repiten
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }

        static public void SkipTakeLinq()
        {

            var myList = new[]
            {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };


            //SKIP
            var skipTwoFirtsValues = myList.Skip(2); // {3, 4, 5, 6, 7, 8, 9, 10}

            var skipLastTwoValues = myList.SkipLast(2); // {3, 4, 5, 6, 7, 8}

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4); // {4, 5, 6, 7, 8} Si es menor que 4 se lo salta

            //TAKE

            var takeFistTwoValues = myList.Take(2); //{1, 2}

            var takeLastTwoValues = myList.TakeLast(2); // {9, 10}

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // {1, 2, 3}

        }

        //Paging with Skip & Take: Le paso la coleccion, el número de página y la cantidad de resultados por página
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage) { 
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);

        }

        //Variables: Uso de variables locales con "let" internamente dentro de una consulta que luego pueden ser implementadas para hacer una validación 

        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Average: {0}", numbers.Average());

            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Query: {0} {1}", number, Math.Pow(number,2));
            }

        }

        //ZIP: Agarro una lista y otra lista con el mismo numero de posiciones y devuelve mezclados
        //{ "1=one", "2=two", ...}

        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word;

        }

        //Repeat (repite un valor N cantidad) & Range (genera valores)
        static public void RepeatRangeLinq() { 
            IEnumerable<int> first1000 = Enumerable.Range(0, 1000);

            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // ("X", "X", "X", "X", "X")
        }


    }
}
