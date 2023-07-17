using AutoMapper;
using WebApplicationtest1.Data.Repositories;
using WebApplicationtest1.Models;
using WebApplicationtest1.ViewModels;

namespace WebApplicationtest1.Services.Impl
{
    public class TransRecordServiceImpl: ITransRecordService
    {
        private readonly ITransRecordRepository _transrecordrepository;
        private readonly IFundRepository _fundrepository;
        private readonly IStockRepository _stockrepository;
        private readonly IMapper _mapper;
        public TransRecordServiceImpl(ITransRecordRepository transrecordrepository, IFundRepository fundrepository, IStockRepository stockrepository, IMapper mapper)
        {
            _transrecordrepository = transrecordrepository;
            _fundrepository = fundrepository;
            _stockrepository = stockrepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TransRecordDto>> GetTransRecordByFundNameAndDateAsync(string fundName, DateTime date)
        {
            //根据传来的参数fundName找到fundId
            var fundId = await _fundrepository.GetFundIdByFundNameAsync(fundName);
            var transRecords = await _transrecordrepository.GetTransRecordByFundIdAndDateAsync(fundId, date);
            var stockIds = transRecords.Select(p => p.StockId).Distinct().ToList();
            var stocks = await _stockrepository.GetStocksByIdsAsync(stockIds);
            var stockDictionary = stocks.ToDictionary(stock => stock.StockId);
            var transRecordDtoList = new List<TransRecordDto>();
            foreach (var item in transRecords)
            {
                if (stockDictionary.TryGetValue(item.StockId, out var stock))
                {
                    var transrecordDto = new TransRecordDto
                    {
                        TranscationId = item.TranscationId,
                        FundName = fundName,
                        StockName = stock.StockName,
                        TransType = item.TransType,
                        TransQuantity = item.TransQuantity,
                        TransAmount = item.TransAmount,
                        TransDate = item.TransDate,
                        UnitPrice = item.UnitPrice,
                    };

                    transRecordDtoList.Add(transrecordDto);
                }
            }
            return transRecordDtoList;

        }


    }
}
