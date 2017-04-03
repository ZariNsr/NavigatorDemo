using NavigatorDemo.Model;
using NavigatorDemo.Interfaces;
using System;

namespace NavigatorDemo.Repositories
{
    public class RegionRepository : BaseEntityRepository, IRegionRepository
    {
        private static int incrementalRegionId = 0;
        private const int _regionInfoIndex = 0;

        public RegionRepository(IInputOutput fileIO)
            : base(fileIO)
        {
        }

        public Region GetRegion()
        {
            var regionInfo = InputText[_regionInfoIndex];
            return CreateRegion(regionInfo);
        }

        private Region CreateRegion(string regionInfo)
        {
            int width;
            int height;

            if (string.IsNullOrEmpty(regionInfo))
            {
                var msg = "InputInterpreter: Input file is empty, application is not able to do the job.";
                throw new ArgumentNullException(msg);          
            }

            var dimension = regionInfo.Split(' ');

            DoValidation(dimension, 2, "region");           

            int.TryParse(dimension[0], out width);
            int.TryParse(dimension[1], out height);

            return new Region(incrementalRegionId++, 0, 0, width, height);
        }
    }
}
