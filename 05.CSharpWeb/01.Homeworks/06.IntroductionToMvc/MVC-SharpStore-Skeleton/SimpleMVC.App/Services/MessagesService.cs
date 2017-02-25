using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpStore.BindingModels;
using SharpStore.Data;
using SharpStore.Models;

namespace SharpStore.Services
{
    class MessagesService
    {
        private SharpStoreContext context;

        public MessagesService(SharpStoreContext context)
        {
            this.context = context;
        }

        public void AddMessageFromBinding(MessageBidning binding)
        {
            Message message = new Message()
            {
                Email = binding.Email,
                MessageText = binding.Message,
                Subject = binding.Subject
            };

            this.context.Messages.Add(message);
            this.context.SaveChanges();
        }
    }
}
