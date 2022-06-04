﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI;
using GUI.Models;

namespace DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return BillDAO.instance;
            }
            private set => instance = value;
        }

        
        public bool createBill(int customerId, int billId, string employeeId, DateTime creatAt, int totalprice)
        {
            try
            {
                using (var context = new Context())
                {
                    Bill bill = new Bill
                    {
                        customerId = customerId,
                        billId = billId,
                        employeeId = employeeId,
                        createAt = creatAt,
                        totalPrice = totalprice
                    };

                    context.Bills.Add(bill);
                    context.SaveChanges();
                }

                return true;

            }
            catch
            {
                return false;
            }
        }


        public bool deleteBill (int id)
        {
            try
            {
                using (var context = new Context())
                {
                    var bill = context.Bills.Find(id);
                    context.Bills.Remove(bill);

                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Bill getBillById(int customerId)
        {
            try
            {
                using (var context = new Context())
                {
                    var bill = context.Bills.SingleOrDefault(c => c.customerId == customerId);
                    return bill;
                    // lấy thông tin hóa đơn thành công
                }
            }
            catch
            {
                return null; // lấy thông tin hóa đơn thất bại
            }
        }

    }
}
