using System;
using System.Collections.Generic;
using System.Text;

namespace BPCClassLibrary
{
    class CarBooking
    {
        private int _orderNo;
        private int _car;

        public CarBooking(int orderNo)
        {
            _orderNo = orderNo;
            _car = 0;
        }

        public int OrderNo
        {
            get => _orderNo;
        }

        public int Car
        {
            get => _car;
            set => _car = value;
        }
    }
}
