using System;
using System.Collections.Generic;
using System.Text;

namespace BPCClassLibrary
{
    public class CarBooking
    {
        private int _orderNo;
        private int _car;
        private int _id;

        public CarBooking(int orderNo, int CBId)
        {
            _orderNo = orderNo;
            _car = 0;
            _id = CBId;
        }

        public CarBooking()
        {

        }

        public int OrderNo
        {
            get => _orderNo;
            set => _orderNo = value;
        }

        public int Car
        {
            get => _car;
            set => _car = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}
