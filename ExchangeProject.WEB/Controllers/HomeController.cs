
namespace ExchangeProject.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExchangeRepository exchangeRepository;
        private readonly ICurrencyRepository currencyRepository;
        private readonly ICurrencyManager currencyManager;
        private readonly IExchangeManager exchangeManager;

        public HomeController(ILogger<HomeController> logger,
            IExchangeRepository exchangeRepository, ICurrencyRepository currencyRepository, 
            ICurrencyManager currencyManager, IExchangeManager exchangeManager)
        {
            _logger = logger;
            this.exchangeRepository = exchangeRepository;
            this.currencyRepository = currencyRepository;
            this.currencyManager = currencyManager;
            this.exchangeManager = exchangeManager;
        }
        public async Task<IActionResult> Index()
        {
            var items = await exchangeRepository.GetAllExchangeDatasAsync();
            return View(items);
        }
        [HttpPost("ConversionForm")]
        public async Task ConversionForm(ConversionRequestViewModel viewModel)
        {
            await exchangeManager.RequestCurrencyExchange(viewModel.clientName, viewModel.personalNumber, viewModel.fromCurrency, viewModel.toCurrency, viewModel.amountToConvert);
        }
  

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
