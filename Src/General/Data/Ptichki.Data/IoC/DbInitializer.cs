using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ptichki.Data.Contexts;
using Ptichki.Domain.Models;
using Ptichki.Tools.Misc.RandomExtensions;
using Ptichki.Tools.Misc.RandomValuesGetters;
using Process = Ptichki.Domain.Models.Process;

namespace Ptichki.Data.IoC
{
    public class DbInitializer
    {
        private readonly PtichkiDbContext _db;
        private readonly ILogger<DbInitializer> _logger;
        private Random _rnd;
        public DbInitializer(ILogger<DbInitializer> logger, PtichkiDbContext db)
        {
            _logger = logger;
            _db = db;
            _rnd = new Random();
        }

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация БД...");

            //_logger.LogInformation("Удаление существующей БД...");
            //await _db.Database.EnsureDeletedAsync().ConfigureAwait(false); //Для отладки. Убрать после тестов. Убрав ConfigureAwait() получим deadlock
            //_logger.LogInformation("Удаление выполнено за {0} мс", timer.ElapsedMilliseconds);

            _logger.LogInformation("Миграция БД...");
            await _db.Database.MigrateAsync().ConfigureAwait(false);
            _logger.LogInformation("Миграция выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await _db.Birds.AnyAsync()) return;

            await InitializeStages();
            await InitializeProcesses();
            await InitializeParameters();
            await InitializeEquipment();
            await InitializeEmployees();
            await InitializeDepartments();
            await InitializeEmployeesInDepartments();
            await InitializeCustomers();
            await InitializeOrders();
            await InitializeBirdTypes();
            await InitializeBirds();
            await InitializeProducts();
            await InitializeBatches();
            await InitializeOrderCompositions();
            await InitializeProcessTechnologies();
            await InitializeWorks();
        }


        private const int BatchesCount = 10;
        private Batch[] _batches;
        private async Task InitializeBatches()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация партий...");

            _batches = Enumerable.Range(1, BatchesCount)
                .Select(i => new Batch
                {
                    CountOfProduct = ProductsCount.ToString(),
                    CreationDate = DateTime.Now,
                    Catalog = _rnd.NextItem(_products)
                })
                .ToArray();

            await _db.Batches.AddRangeAsync(_batches);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация партий выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int BirdsCount = 10;
        private Bird[] _birds;
        private async Task InitializeBirds()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация птиц...");

            _birds = Enumerable.Range(1, BirdsCount)
                .Select(i => new Bird
                {
                    Name = $"Имя птицы {i}",
                    BirdSex = BirdRandomValuesGetter.GetRandomGender(),
                    BirdAge = BirdRandomValuesGetter.GetRandomAge(),
                    BirdWeight = BirdRandomValuesGetter.GetRandomWeight(),
                    WaterConsumption = BirdRandomValuesGetter.GetRandomWaterConsumption(),
                    FeedConsumption = BirdRandomValuesGetter.GetRandomFeedConsumption(),
                    BirdTypes = _rnd.NextItem(_birdTypes)
                })
                .ToArray();

            await _db.Birds.AddRangeAsync(_birds);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация птиц выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int BirdTypesCount = 4;
        private BirdType[] _birdTypes;
        private async Task InitializeBirdTypes()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация видов птиц...");

            _birdTypes = Enumerable.Range(1, BirdTypesCount)
                .Select(i => new BirdType
                {
                    Name = $"Наименование вида птицы {i}"
                })
                .ToArray();

            await _db.BirdTypes.AddRangeAsync(_birdTypes);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация видов птиц выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int CustomersCount = 20;
        private Customer[] _customers;
        private async Task InitializeCustomers()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация клиентов...");

            _customers = Enumerable.Range(1, CustomersCount)
                .Select(i => new Customer
                {
                    Surname = $"Фамилия {i}",
                    Name = $"Имя {i}",
                    Patronymic = $"Отчество {i}",
                    DateOfBirthday = DateTime.Now,
                    PhoneNumber = CustomerRandomValuesGetter.GetRandomPhoneNumber()
                })
                .ToArray();

            await _db.Customers.AddRangeAsync(_customers);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация клиентов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int DepartmentsCount = 5;
        private Department[] _departments;
        private async Task InitializeDepartments()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация отделов...");

            _departments = Enumerable.Range(1, DepartmentsCount)
                .Select(i => new Department
                {
                    Name = $"Название отдела {i}",
                    DepartmentType = $"Название типа отдела {i}"
                })
                .ToArray();

            await _db.Departments.AddRangeAsync(_departments);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация отделов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int EmployeesCount = 10;
        private Employee[] _employees;
        private async Task InitializeEmployees()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация сотрудников...");

            _employees = Enumerable.Range(1, EmployeesCount)
                .Select(i => new Employee
                {
                    Surname = $"Фамилия сотрудника {i}",
                    Name = $"Имя сотрудника {i}",
                    Patronymic = $"Отчество сотрудника {i}",
                    DateOfBirthday = DateTime.Now,
                    PhoneNumber = EmployeeRandomValuesGetter.GetRandomPhoneNumber(),
                    PassportSerial = $"Серия паспорта {i}",
                    PassportNumber = $"Номер паспорта {i}"
                })
                .ToArray();

            await _db.Employees.AddRangeAsync(_employees);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация сотрудников выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int EmployeesInDepartmentsCount = 10;
        private EmployeesInDepartments[] _employeesInDepartments;
        private async Task InitializeEmployeesInDepartments()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация сотрудников в отделах...");

            _employeesInDepartments = Enumerable.Range(1, EmployeesInDepartmentsCount)
                .Select(i => new EmployeesInDepartments
                {
                    Employee = _rnd.NextItem(_employees),
                    Department = _rnd.NextItem(_departments)
                })
                .ToArray();

            await _db.EmployeesInDepartments.AddRangeAsync(_employeesInDepartments);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация сотрудников в отделах выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int EquipmentCount = 20;
        private Equipment[] _equipment;
        private async Task InitializeEquipment()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация оборудования...");

            _equipment = Enumerable.Range(1, EquipmentCount)
                .Select(i => new Equipment
                {
                    Name = $"Наименование оборудования {i}"
                })
                .ToArray();

            await _db.Equipment.AddRangeAsync(_equipment);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация оборудования выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int OrdersCount = 30;
        private Order[] _orders;
        private async Task InitializeOrders()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация заказов...");

            _orders = Enumerable.Range(1, OrdersCount)
                .Select(i => new Order
                {
                    Customer = _rnd.NextItem(_customers),
                    OrderDate = DateTime.Now,
                    OrderPrice = OrdersRandomValuesGetter.GetRandomPrice(),
                    TransactionCode = OrdersRandomValuesGetter.GetRandomTransactionCode()
                })
                .ToArray();

            await _db.Orders.AddRangeAsync(_orders);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация заказов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int OrderCompositionsCount = 30;
        private OrderComposition[] _orderCompositions;
        private async Task InitializeOrderCompositions()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация составов заказов...");

            _orderCompositions = Enumerable.Range(1, OrderCompositionsCount)
                .Select(i => new OrderComposition
                {
                    Batch = _rnd.NextItem(_batches),
                    Order = _rnd.NextItem(_orders)
                })
                .ToArray();

            await _db.OrderCompositions.AddRangeAsync(_orderCompositions);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация составов заказов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int ParametersCount = 30;
        private Parameter[] _parameters;
        private async Task InitializeParameters()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация параметров...");

            _parameters = Enumerable.Range(1, ParametersCount)
                .Select(i => new Parameter
                {
                    Name = $"Наименование параметра {i}",
                    Description = $"Описание параметра {i}"
                })
                .ToArray();

            await _db.Parameters.AddRangeAsync(_parameters);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация параметров выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int ProcessesCount = 20;
        private Process[] _processes;
        private async Task InitializeProcesses()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация процессов...");

            _processes = Enumerable.Range(1, ProcessesCount)
                .Select(i => new Process
                {
                    Name = $"Наименование процесса {i}",
                    Stage = _rnd.NextItem(_stages)
                })
                .ToArray();

            await _db.Processes.AddRangeAsync(_processes);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация процессов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int ProcessTechnologyCount = 20;
        private ProcessTechnology[] _processTechnologies;
        private async Task InitializeProcessTechnologies()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация технологии процессов...");

            _processTechnologies = Enumerable.Range(1, ProcessTechnologyCount)
                .Select(i => new ProcessTechnology
                {
                    Name = $"Наименование процесса технологии {i}",
                    Value = $"Значение {i}",
                    ProductCatalog = _rnd.NextItem(_products),
                    Process = _rnd.NextItem(_processes),
                    Equipment = _rnd.NextItem(_equipment),
                    Parameter = _rnd.NextItem(_parameters)
                })
                .ToArray();

            await _db.ProcessTechnologies.AddRangeAsync(_processTechnologies);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация технологии процессов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int ProductsCount = 10;
        private ProductCatalog[] _products;
        private async Task InitializeProducts()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация продуктов...");

            _products = Enumerable.Range(1, BatchesCount)
                .Select(i => new ProductCatalog
                {
                    Name = $"Продукт {i}",
                    Weight = _rnd.Next(1, 10),
                    Composition = $"Компонент {i}"
                })
                .ToArray();

            await _db.Products.AddRangeAsync(_products);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация каталога продуктов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int StagesCount = 5;
        private Stage[] _stages;
        private async Task InitializeStages()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация этапов...");

            _stages = Enumerable.Range(1, StagesCount)
                .Select(i => new Stage
                {
                    Name = $"Название этапа {i}",
                })
                .ToArray();

            await _db.Stages.AddRangeAsync(_stages);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация каталога этапов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int WorksCount = 20;
        private Work[] _works;
        private async Task InitializeWorks()
        {
            var timer = Stopwatch.StartNew();
            _logger.LogInformation("Инициализация работ...");

            _works = Enumerable.Range(1, WorksCount)
                .Select(i => new Work
                {
                    Name = $"Название работы {i}",
                    DueDate = DateTime.Now,
                    Batch = _rnd.NextItem(_batches),
                    Employee = _rnd.NextItem(_employees),
                    Process = _rnd.NextItem(_processes),
                    Equipment = _rnd.NextItem(_equipment),
                    Bird = _rnd.NextItem(_birds)
                })
                .ToArray();

            await _db.Works.AddRangeAsync(_works);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Инициализация работ выполнена за {0} мс", timer.ElapsedMilliseconds);
        }
    }
}
