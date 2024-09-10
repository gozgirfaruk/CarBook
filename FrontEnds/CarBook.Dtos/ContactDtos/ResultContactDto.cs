using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dtos.ContactDtos
{
    public class ResultContactDto
    {
            public int contactId { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string subject { get; set; }
            public string messageBody { get; set; }
            public DateTime sendDate { get; set; }
        

    }
}
