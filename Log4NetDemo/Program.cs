using Autofac;
using log4net;
using log4net.Config;
using System.Linq;
using System.Reflection;

namespace Log4NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();
            builder.RegisterModule<LoggingModule>();
            builder.RegisterType<ADemoService>().As<IAmAService>();
            var container = builder.Build();


            var service = container.Resolve<IAmAService>();
            service.DisplayWord();
           
        }
    }


    public interface IAmAService
    {
        void DisplayWord();
    }
    public class ADemoService: IAmAService
    {
        ILog logger;
        public ADemoService(ILog logger)
        {
            this.logger = logger;
        }

        public void DisplayWord()
        {

            logger.Info("testing");
        }
    }

}
