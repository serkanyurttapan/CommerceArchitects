using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDomainCore
{
    //Aggregate root, birbiri ile alakalı farklı entitylerin bir bütünlük oluşturabilmeleri, tutarlı olabilmeleri ve iş kurallarını ya da akışlarını gerçekleştirebilmeleri için bir arada kullanılması durumudur.
    public interface IAggregateRoot
    {
    }
}