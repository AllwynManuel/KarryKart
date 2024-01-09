using Entities.Models.ManufacturesClass;
using Entities.Models.ProductClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IGiftCard
    {
        Task<IEnumerable<GiftCard>> GetGiftCard();
        Task<GiftCard> GetGiftCardId(int giftCardid);
        Task<GiftCard> AddGiftCard(GiftCard giftCard);
        Task<GiftCard> UpdateGiftCard(GiftCard giftCard);
        Task DeleteGiftCard(int giftCardid);
    }
}
