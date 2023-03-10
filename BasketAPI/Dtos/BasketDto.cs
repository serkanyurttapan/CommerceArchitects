namespace BasketAPI.Dtos
{
    public class BasketDto
    {
        public UserDto UserDto { get; set; }
        public List<BasketItemDto> BasketItemDtos { get; set; }
        public decimal BasketTotalPrice()
        {
            return BasketItemDtos.Sum(x => x.Price * x.Quantity);
        }
    }
}
