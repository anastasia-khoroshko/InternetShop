using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using EShopDomainModel.Interfaces;
using EShopDomainModel.Concrete;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class TestsDomainModel
    {
        [TestMethod]
        public void Add_Item_To_ShoppingCart()
        {
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateStub<IDiscountPolicy>();
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 3
            };
            Item theItem2 = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Fire",
                Price = 200,
                Amount = 4
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            mockItemRepository.Stub(x => x.GetByPredicate(theItem2.Id)).Return(theItem2);
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            theItem.Amount = 2;
            theItem2.Amount = 1;
            shoppingCart.AddInCart(theItem);
            shoppingCart.AddInCart(theItem2);
            Assert.AreEqual(shoppingCart.Count, 2);
            Assert.AreEqual(shoppingCart.AllItems[0], theItem);
            Assert.AreEqual(shoppingCart.AllItems[1], theItem2);
        }

        [TestMethod]
        public void When_Add_The_Same_item()
        {
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateStub<IDiscountPolicy>();
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 6
            };
            Item addItem = new Item()
            {
                Id = theItem.Id,
                Name = theItem.Name,
                Price = theItem.Price,
                Amount = 2
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            shoppingCart.AddInCart(addItem);
            shoppingCart.AddInCart(addItem);
            Assert.AreEqual(shoppingCart.AllItems[0].Amount, 4);
            Assert.AreEqual(shoppingCart.Count, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(FormedOrderException))]
        public void When_Add_Null_Item()
        {
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateStub<IDiscountPolicy>();
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 6
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            Item addItem = null;
            shoppingCart.AddInCart(addItem);
        }

        [TestMethod]
        [ExpectedException(typeof(FormedOrderException))]
        public void When_Add_Amount_Bigger_Existing()
        {
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateStub<IDiscountPolicy>();
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 3
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            Item addItem = new Item()
            {
                Id = theItem.Id,
                Name = theItem.Name,
                Price = theItem.Price,
                Amount = 2
            };
            shoppingCart.AddInCart(addItem);
            shoppingCart.AddInCart(addItem);
        }

        [TestMethod]
        public void Deleting_Item_From_Cart()
        {
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateStub<IDiscountPolicy>();
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 3
            };
            Item theItem2 = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Fire",
                Price = 200,
                Amount = 4
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            mockItemRepository.Stub(x => x.GetByPredicate(theItem2.Id)).Return(theItem2);
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            theItem.Amount = 2;
            theItem2.Amount = 1;
            shoppingCart.AddInCart(theItem);
            shoppingCart.AddInCart(theItem2);
            shoppingCart.DeleteFromCart(theItem.Id);
            Assert.AreEqual(shoppingCart.Count, 1);
            Assert.AreNotEqual(shoppingCart.AllItems[0], theItem);
            Assert.AreEqual(shoppingCart.AllItems[0], theItem2);
        }

        [TestMethod]
        [ExpectedException(typeof(FormedOrderException))]
        public void Deleting_No_Existing_In_Cart_Item()
        {
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateStub<IDiscountPolicy>();
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 3
            };
            Item theItem2 = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Fire",
                Price = 200,
                Amount = 4
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            theItem.Amount = 2;
            shoppingCart.AddInCart(theItem);
            shoppingCart.DeleteFromCart(theItem2.Id);
        }

        [TestMethod]
        public void Update_ShoppingCart()
        {
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateStub<IDiscountPolicy>();
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 3
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            theItem.Amount = 2;
            shoppingCart.AddInCart(theItem);
            theItem.Name = "Parrot";
            shoppingCart.UpdateCart(theItem);
            Assert.AreEqual(shoppingCart.AllItems[0], theItem);
        }

        [TestMethod]
        [ExpectedException(typeof(FormedOrderException))]
        public void Update_ShoppingCart_null_item()
        {
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateStub<IDiscountPolicy>();
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 3
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            theItem.Amount = 2;
            shoppingCart.AddInCart(theItem);
            theItem = null;
            shoppingCart.UpdateCart(theItem);
        }

      

        [TestMethod]
        [ExpectedException(typeof(FormedOrderException))]
        public void Make_PaymentOrder_When_Order_Not_Formed()
        {
            var mockPayService = MockRepository.GenerateMock<IPaymentService>();
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var discount = MockRepository.GenerateMock<IDiscountPolicy>();
            decimal price = 105;
            string card = "105-258-5987-525";
            var shoppingCart = new ShoppingCart(mockItemRepository, discount);
            mockPayService.Stub(x => x.Pay(price, card)).Return(true);
            shoppingCart.MakePayment(mockPayService, card);
        }

        [TestMethod]
        public void MakePayment_When_Order_Formed()
        {        
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var mockDiscount = MockRepository.GenerateMock<IDiscountPolicy>();
            var mockOrderRepository = MockRepository.GenerateStub<IRepository<Order>>();
            var mockDetailRepository = MockRepository.GenerateStub<IRepository<OrderDetail>>();
            var mockPayService = MockRepository.GenerateMock<IPaymentService>();
            Discount discount = new Discount()
            {
                Id = Guid.NewGuid(),
                Value = 15
            };
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 3,
                DiscountId = discount.Id
            };
            string card = "105-258-5987-525";
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            var shoppingCart = new ShoppingCart(mockItemRepository, mockDiscount);
            mockPayService.Stub(x => x.Pay(shoppingCart.Order.TotalPrice, card)).Return(true);
            shoppingCart.AddInCart(theItem);
            shoppingCart.SaveCart(mockOrderRepository, mockDetailRepository);
            shoppingCart.MakePayment(mockPayService, card);
            Assert.AreEqual(shoppingCart.Order.State.StateOrder, StateOrder.Ordered);
        }

        [TestMethod]
        public void Make_Payment_By_Exist_Order()
        {
            var mockOrderRepository = MockRepository.GenerateMock<IRepository<Order>>();
            var mockPayment = MockRepository.GenerateMock<IPaymentService>();
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                TotalPrice = 105,
                State = new State { StateOrder = StateOrder.InProgress }
            };
            string card = "105-58-4521-152";
            mockOrderRepository.Stub(x => x.GetByPredicate(order.Id)).Return(order);
            var PayService = new Payment();
            mockOrderRepository.Expect(y => y.Update(order));
            mockPayment.Stub(x => x.Pay(order.TotalPrice, card)).Return(true);
            PayService.Pay(mockPayment, mockOrderRepository, order.Id, order.TotalPrice, card);
            Assert.AreEqual(order.State.StateOrder, StateOrder.Ordered);
            mockOrderRepository.VerifyAllExpectations();
        }


        [TestMethod]
        public void Save_ShoppingCart()
        {
            var mockOrderRepository = MockRepository.GenerateMock<IRepository<Order>>();
            var mockDetailRepository = MockRepository.GenerateMock<IRepository<OrderDetail>>();
            var mockItemRepository = MockRepository.GenerateMock<IRepository<Item>>();
            var mockDiscount = MockRepository.GenerateMock<IDiscountPolicy>();
            Discount discount = new Discount()
            {
                Id = Guid.NewGuid(),
                Value = 15
            };
            Item theItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Mile",
                Price = 350,
                Amount = 3,
                DiscountId = discount.Id
            };
            mockItemRepository.Stub(x => x.GetByPredicate(theItem.Id)).Return(theItem);
            var shoppingCart = new ShoppingCart(mockItemRepository, mockDiscount);
            shoppingCart.AddInCart(theItem);
            mockItemRepository.Expect(x => x.Update(theItem));
            mockDiscount.Stub(x => x.CalculatePrice(shoppingCart.AllItems)).Return(157);
            Order order = shoppingCart.Order;
            order.TotalPrice = 157;
            order.State = new State { StateOrder = StateOrder.InProgress };
            mockOrderRepository.Expect(y => y.Create(order));
            shoppingCart.SaveCart(mockOrderRepository, mockDetailRepository);
            mockOrderRepository.VerifyAllExpectations();
        }
    }
}
