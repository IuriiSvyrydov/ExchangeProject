
using ExchangeProject.Core.Repositories;

namespace ExchangeProject.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExchangeRepository _exchangeRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyManager _currencyManager;
        private readonly IExchangeManager _exchangeManager;

        public HomeController(ILogger<HomeController> logger,
            IExchangeRepository exchangeRepository, ICurrencyRepository currencyRepository, 
            ICurrencyManager currencyManager, IExchangeManager exchangeManager)
        {
            _logger = logger;
            _exchangeRepository = exchangeRepository;
            _currencyRepository = currencyRepository;
            _currencyManager = currencyManager;
            _exchangeManager = exchangeManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _exchangeRepository.GetAllExchangeDatasAsync();
            return View(items);
        }
        [HttpPost("ConversionForm")]
        public async Task ConversionForm(ConversionRequestViewModel viewModel)
        {
            await _exchangeManager.RequestCurrencyExchange(viewModel.clientName, viewModel.personalNumber, viewModel.fromCurrency, viewModel.toCurrency, viewModel.amountToConvert);
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
