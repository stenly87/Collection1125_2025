// коллекции и тп

// List - список объектов
// пример списка:
List<int> ints = new List<int>(100); // создание и инициализация списка с элементами int
// <> - дженерики, обобщения. В угловых скобочках обозначается конкретный
// тип данных, который будет использоваться внутри класса
// = new List<int>(100); 100 - это начальная "вместимость" для внутреннего массива
// писать вместимость необязательно, но если мы собираемся сразу добавить
// в коллекцию большое число объектов, то желательно, чтобы предупредить
// лишние пересоздания внутреннего массива

// добавление данных
ints.Add(1); // добавление одного элемента
ints.AddRange(1, 2, 3, 4, 5); // добавление множества элементов
ints.AddRange(new int[] { 1, 2, 3, 4, 5 });// или так
//ints = new List<int>(new int[] { 1, 2, 3, 4, 5 }); // или так
ints.Remove(1); // удаление первого попавшегося объекта с значением 1
ints.RemoveAt(0); // удаление объекта по индексу 0
ints.RemoveRange(1, 2); // удаление двух ячеек, начиная с индекса 1

// c коллекцией можно работать как с массивом
ints[0] = 1;
Console.WriteLine(ints[0]);
foreach (int i in ints)
    Console.WriteLine(i);

// используя лямбда-выражения, мы получаем доступ к многим 
// полезным методам
ints.RemoveAll(s => s > 5);

// лямбда-выражение - анонимный метод, который указывается в коде
// и передается сразу в делегат. Дальше этот метод используется 
// через делегат. Польза - не нужно плодить много маленьких
// методов, не нужно придумывать много имен, краткий синтаксис

// синтаксис лямбда: (аргументы) => тело или возращаемый результат
// если тело состоит из одной строки, которая является результатом,
// то можно опустить фигурные скобки и слово return

// (x,y) => x + y // лямбда, складывающая 2 числа
// s => s > 1 // лямбда, сравнивающая аргумент с 1

// тип аргументов и возвращаемого значения будет зависеть
// от принимающего делегата, поэтому в лямбде типы не указываются

// сортировка по умолчанию
ints.Sort();

// сортировка с использованием лямбды
// лямбда будет использована для сравнения объектов в коллекции
ints.Sort((x, y) => x.CompareTo(y)); // asc
ints.ForEach(x => Console.WriteLine(x)); // тоже лямбда 
ints.Sort((x, y) => y.CompareTo(x)); // desc
ints.ForEach(x => Console.WriteLine(x));

void Test() => Console.WriteLine("test"); // метод в стиле лямбда

//class TestClass
//{
//    private string title;

//    public string Title 
//    { // свойство в стиле лямбда (убрали {} и return)
//        get => title; 
//        set => title = value;
//    }
//}


// в фреймворке есть ряд стандартных делегатов (тоже с обобщением)
// которые удобно использовать и которые часто требуются в 
// стандартных классах
// Action - делегат, который описывает процедуру, может иметь ряд аргументов
// тип аргументов указывается через обобщение
// в делегат с двумя аргументами int передается лямбда
Action<int, int> action = (x, y) => Console.WriteLine(x + y);
action(1, 2); // вызов лямбды через делегат

// Func - делегат, который описывает функцию, последний тип в нем
// это тип возвращаемого значения
// в делегат с двумя аргументами int передается лямбда, возвращающая string
Func<int, int, string> func = (x, y) => (x + y).ToString();
string result = func(1, 2);

// найти первый ненулевой элемент
int resultFirst = ints.FirstOrDefault(s => s != 0);
// найти последний ненулевой элемент
var resultLast = ints.LastOrDefault(s => s != 0);

// выбрать все элементы и преобразовать каждый
List<string> strings = ints.Select(s => s.ToString()).ToList();
// Select возвращает тип IEnumerable<T>, это интерфейс перечислений
// для удобства работы его лучше преобразовать в массив или список

// пример
List<string> log = new List<string>();
string command = null;
while (command != "exit")
{
    Console.Write("Команда? ");
    command = Console.ReadLine();
    log.Add(command);
}

Console.WriteLine("Были использованы команды:");
log.ForEach(s => Console.WriteLine(s));

int notZero = ints.FirstOrDefault(s => s != 0);
List<int> notZeros = ints.Where(s => s != 0).ToList();

// dictionary
//Dictionary<тип ключа, тип значения>
// каждый объект типа Human имеет ключ типа string
// все ключи в словаре должны быть уникальными
Dictionary<string, Human> dictionary = new();
dictionary.Add("first", new Human { Name = "Володя" });
dictionary.Add("second", new Human { Name = "Света" });
// при повторной попытке добавить существующий ключ
// получим exception, что ключ уже существует
//dictionary.Add("first", new Human { Name = "Света" });

Human testHuman = dictionary["first"];
dictionary["first"] = new Human { Name = "Не Володя" };

// удаление объекта по ключу
dictionary.Remove("first");
// кол-во объектов в словаре
int count = dictionary.Count;
// можно перебрать все имеющиеся значения
foreach (var value in dictionary)
{
    Console.WriteLine(value.Key);
    Console.WriteLine(value.Value);
}
// теперь храним объекты Inventory, Human является ключом
Dictionary<Human, Inventory> inventory = new();

inventory.Add(testHuman, new Inventory { Gold = 1000 });

var inventoryHuman = inventory[testHuman];

List<Item> items = new List<Item>();
items.AddRange(new Item[] {
 new Item{ ID = 1, Title = "Кирпич"},
  new Item{ ID = 2, Title = "Стринги" },
   new Item{ ID = 3, Title = "Зажигалка" },
});

Item findItem = items.FirstOrDefault(s => s.ID == 3);

Dictionary<int, Item> itemsDictionary = new();

itemsDictionary.Add(1, new Item { ID = 1, Title = "Кирпич" });
itemsDictionary.Add(2, new Item { ID = 2, Title = "Стринги" });
itemsDictionary.Add(3, new Item { ID = 3, Title = "Зажигалка" });
// эта операция будет гораздо быстрее,
// чем items.FirstOrDefault(s => s.ID == 3);
findItem = itemsDictionary[3];

// особенно будет ощущаться разница, если поиск в коллекции происходит в цикле. 
// такой же поиск по ключу из словаря будет работать мгновенно
// FirstOrDefault будет выполняться тем дольше, чем больше элементов в коллекции
// доступ по ключу из словаря от кол-ва объектов в словаре не зависит

// перед чтением значения следует всегда проверять наличие ключа:
bool exist = itemsDictionary.ContainsKey(1);

// Stack Queue
Queue<Human> humansQueue = new(); // FIFO *первый пришел - первый вышел
Stack<Item> itemsStack = new(); // LIFO *последний пришел - первый вышел

itemsStack.Push(findItem); // добавление объекта на стек
Item getItem = itemsStack.Pop(); // получить и убрать объект из стека
Item viewItem = itemsStack.Peek(); // получить, но не убирать объект из стека
// кол-во записей в стеке
int stackCount = itemsStack.Count;

// будем забирать со стека объекты до тех пор, пока стек не очистится
while (stackCount > 0)
{
    Item takeItem = itemsStack.Pop();
    Console.WriteLine("Очищаем стек");
    stackCount = itemsStack.Count;
}


Console.WriteLine("рекурсия:");
void TestRecursive(int i)
{
    i--;
    if (i > 0)
        TestRecursive(i);
    Console.WriteLine(i);
}
TestRecursive(10);

Console.WriteLine("Теперь почти то же со стеком");
Stack<int> ints1 = new Stack<int>();
ints1.Push(10);
while (ints1.Count > 0)
{
    int i = ints1.Pop();
    i--;
    if (i > 0)
        ints1.Push(i);
    Console.WriteLine(i);
}

// пример очереди

humansQueue.Enqueue(new Human { Name = "Я первый" });
humansQueue.Enqueue(new Human { Name = "Я второй" });
humansQueue.Enqueue(new Human { Name = "Я третий" });

Human nextHuman1 = humansQueue.Dequeue(); // первый
Human nextHuman2 = humansQueue.Dequeue(); // второй
// кол-во человек в очереди
int queueCount = humansQueue.Count;
// выдает объект, но не удаляет его из очереди
Human viewNextHuman = humansQueue.Peek();