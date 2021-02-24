using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace $rootnamespace$.Create$fileinputname$
{
    public class $safeitemname$ : IRequestHandler<Create$fileinputname$Command, Create$fileinputname$CommandResponse>
    {
        private readonly IMapper _mapper;
        

        public $safeitemname$(IMapper mapper)
        {
            _mapper = mapper;
        }

         public Task<Create$fileinputname$CommandResponse> Handle(Create$fileinputname$Command request, CancellationToken cancellationToken)
        {
            
        }
    }
}
