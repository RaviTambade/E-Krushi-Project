



-- ROLE TABLE DATA
INSERT INTO roles(name) VALUES ('Shop owner');
INSERT INTO roles(name) VALUES ('Customer');
INSERT INTO roles(name) VALUES ('Supplier');
INSERT INTO roles(name) VALUES ('Shipper');
INSERT INTO roles(name) VALUES ('SubjectMatterExpert');


INSERT INTO userroles(userid,roleid) VALUES (1,1);

INSERT INTO userroles(userid,roleid) VALUES (2,2);

INSERT INTO userroles(userid,roleid) VALUES (3,2);

INSERT INTO userroles(userid,roleid) VALUES (11,3);

INSERT INTO userroles(userid,roleid) VALUES (12,3);

INSERT INTO userroles(userid,roleid) VALUES (6,4);

INSERT INTO userroles(userid,roleid) VALUES (7,4);

INSERT INTO userroles(userid,roleid) VALUES (8,5);

INSERT INTO userroles(userid,roleid) VALUES (9,5);

 

 

INSERT INTO suppliers(corporateid,userid) VALUES(8,11);

INSERT INTO suppliers(corporateid,userid) VALUES(9,12);

 
SELECT * FROM userroles;

INSERT INTO categories(title,image) VALUES('seeds',"/assets/seed.jpeg");
INSERT INTO categories(title,image) VALUES('Agriculture implements',"/assets/Agri Equipments.jpeg");
INSERT INTO categories(title,image) VALUES('fertilizers',"/assets/fertilizer.jpeg");
INSERT INTO categories(title,image) VALUES('pesticides',"/assets/pestisides.jpeg");
INSERT INTO categories(title,image) VALUES('catel feed',"/assets/cattle feed.jpeg");
INSERT INTO categories(title,image) VALUES('organic product',"/assets/organic.jpeg");
INSERT INTO categories(title,image) VALUES('Kisan Mitra',"/assets/kisan mitra.jpeg");

--seeds
INSERT INTO products(title,description,image,categoryid) VALUES('oats','
For healthier and nutritiously growing food preferences, Oats are largely recommended by the topmost dieticians and nutritionists. Oats are the quintessential healthy food and make for an excellent and highly nutritious meal or even a snack. Being considered a superfood with an abundance of dietary fibres, beta-glucan, and several essential nutrients, Oats have become an everyday partner of every health-conscious individual. However, not everyone is familiar with the different kinds of Oats, having different generics, available in the market. Goodness and Wellness are the two common essences amongst all the different oats varieties. Let’s have a better understanding of the different types of oats, their key features, and nutrition components.

','/assets/oat.jfif',1);
INSERT INTO products(title,description,image,categoryid)VALUES('wheat','Wheat is the second most important staple food after rice consumed by 65% of the population in India and is likely to increase further due to changes in food habits. Wheat is mostly consumed in the form of ‘chapati’ in our country for which bread wheat is cultivated in nearly 95 per cent of the cropped area. ','/assets/wheat.jpg',1);
INSERT INTO products(title,description,image,categoryid) VALUES('corn','Corn is one of the world’s most productive and dominant crops. It is grown extensively as food for both humans and livestock, as a biofuel, and as a crude material in industry. Corn is the third largest plant-based food source in the world.','/assets/corn.jfif',1);

--Agricultural Implements
INSERT INTO products(title,description,image,categoryid) VALUES('tractor','tractor high-power, low-speed traction vehicle and power unit mechanically similar to an automobile or truck but designed for use off the road. The two main types are wheeled, which is the earliest form, and continuous track','/assets/tractor.jfif',2);
INSERT INTO products(title,description,image,categoryid) VALUES('harvesters','harvester, in farming, any of several machines for harvesting; the design and function of harvesters varies widely according to crop. See binder; combine; corn harvester; cotton harvester; header; reaper; thresher; windrower. See also entries for particular crops (e.g., hay, for hay-cutting equipment).','/assets/harvestor.jfif',2);


 -- FERTILIZERS
INSERT INTO products(title,description,image,categoryid) VALUES('Urea','Urea is the chief nitrogenous end product of the metabolic breakdown of proteins in all mammals and some fishes. It occurs not only in the urine of mammals but also in their blood, bile, milk, and perspiration.','/assets/UREA.png',3);
INSERT INTO products(title,description,image,categoryid) VALUES('12-32-16','This is one of the highest nutrients containing NPK complex fertiliser with total nutrients of 60%
Nitrogen and Phosphate are available in the ratio 1:2.6 as in the case of DAP, but in Mahadhan 12:32:16 also contains 16% Potash additionally
Mahadhan 12:32:16 helps the young plants to grow faster, even under adverse soil or climatic condition','/assets/12-32-16.jpeg',3);
INSERT INTO products(title,description,image,categoryid) VALUES('10-26-26','Improves nutrient availability & reduce nutrient loss.
It increases crop yield by 10% to 15%.
Increases CEC and nutrient holding capacity of soil.
Rich in organic carbon and mineral substances essential to plant growth
Retains water soluble fertilisers and releases in root zones as needed
Increases plant uptake of nutrients
','/assets/10-26-26.jpeg',3);


--pestisides
INSERT INTO products(title,description,image,categoryid) VALUES('Admire','Admire contains Imidacloprid, one of the world best selling insecticides. It is a systemic insecticide belonging to the chemical class of neonicotinoids and is very effective against various insect pests','/assets/mira.webp',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Rogor','It can be applied by mixing 1-2 ml with a liter of water and spraying over the concerned plants.
Rogor Is 30% EC Formulation Of Dimethoate
It Is Highly Effective In Controlling The Sucking And Caterpillar Pests
It Is highly Compatible With Other Insecticides And Fungicides','/assets/Rogor.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Antracol',
'Antracol contains Propineb, a contact fungicide with broad spectrum activity against various diseases of rice, chilli, grapes, potato and other vegetables and fruits. Propineb is a polymeric zinc-containing dithiocarbamate. Due to the release of zinc, the application of Antracol results in greening effect on the crop and subsequent improvement in quality of produce.','/assets/antracol.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Avatar','Avtar is a Broad-spectrum fungicide, which controls large number of diseases with its multisite and systemic action. Avatar is an effective fungicide that is useful for all crops and vegetables.','/assets/Avtar.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('coragen','ABOUT PRODUCT
Coragen® insecticide is an anthranilic diamide Broad Spectrum insecticide in the form of a suspension concentrate.
Coragen® insecticide is particularly active on Lepidopteran insect pests, primarily as a larvicide.
Coragen® insecticide is powered by active ingredient Rynaxypyr® active which has a unique mode of action that controls pests resistant to other insecticides.
Coragen® insecticide is selective & safe for non-target arthropods and conserves natural parasitoids, predators and pollinators.','/assets/coragen.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Zyme','V-Zyme Sport is specially designed for turf , its a unique formulation of micronutrients with amino acid, growth-supporting co-factors and biostimulator, consisting of various minerals suspended in amino acids.
The micronutrients are used in such a peculiar form that ensures the bioavailability of these micronutrients to the maximum extent. Such bioavailability of these micronutrients is rarely seen in any other products available in the market.','/assets/zyme.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Melody','Melody Duo is a modern fungicide containing the two active ingredients Iprovalicarb and Propineb.','/assets/Melody.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Goal','Goal® contains oxyfluorfen as active ingredient which belongs to diphenyl ether.
As pre-emergence, Goal® forms a chemical barrier on the soil surface and affects weed plants through direct contact at emergence.
Actively growing plants are very susceptible to Goal® as post-emergence action','/assets/Goal.jpeg',4);
INSERT INTO products(title,description,image,categoryid) VALUES('Targa-super','Targa Super is selective, systemic herbicide of Aryloxyphenoxy-propionates group. It is used to control narrow leaf weeds in broad leaf crops.','/assets/targa-super.png',4);

-- -- catelfeed
INSERT INTO products(title,description,image,categoryid) VALUES('Sarki pend','Perfect mixture
Quality examined
Completely organic
Lower price
Free from damage by water','/assets/sarki pend.jpeg',3);

INSERT INTO products(title,description,image,categoryid) VALUES('Kandi','This useful to cow, Goat, buffawlo. This is one of the most important feed for animal','/assets/kandi.jpeg',3);

INSERT INTO products(title,description,image,categoryid) VALUES('Bhusa','This useful to cow, Goat, buffawlo. This is one of the most important feed for animal','/assets/bhusa.jpeg',3);



--Organic product
INSERT INTO products(title,description,image,categoryid) VALUES('bone meal','Bonemeal is a product created from the waste resulting from the slaughter of animals, especially beef cattle, by meat processors. It is a white powder made by grinding either raw or steamed animal bones','/image/bonemeal.jpg',3);

select * from products



-- ORDERS DATA
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-12-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-11-01 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-10-01 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2021-12-01 12:10:12','2021-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2022-11-01 12:11:00','2022-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2023-10-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-05-01 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');

INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-12-05 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-11-05 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-10-10 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-09-01 12:10:12','2021-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-08-01 12:11:00','2022-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-07-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-06-01 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-05-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-04-01 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-03-01 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-02-01 12:10:12','2020-02-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:11:00','2020-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:13:11','2023-01-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-05-02 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');

INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-02-05 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-02-05 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-02-10 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:10:12','2021-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:11:00','2022-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-01-01 12:14:13','2020-05-02 10:12:12',7,5020,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-03-01 12:12:12','2020-12-02 10:12:12',1,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-03-01 12:12:12','2020-11-02 10:02:12',2,800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-03-01 12:12:12','2020-10-02 10:22:12',3,700,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-04-01 12:10:12','2020-12-02 10:12:12',4,500,'initiated');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-04-01 12:11:00','2020-11-02 10:02:12',5,1800,'delivered');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-04-01 12:13:11','2023-10-02 10:22:12',6,7100,'cancelled');
INSERT INTO orders(orderdate,shippeddate,custid,total,status) VALUES ('2020-06-02 12:14:13','2020-06-02 10:12:12',7,5020,'initiated');

-- ORDER_DETAILS DATA
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (1,2,20);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (2,2,25);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (3,1,40);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (4,3,15);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (4,3,48);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (5,5,41);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (7,6,63);
INSERT INTO orderdetails(orderid,productid,quantity) VALUES (6,2,63);


-- CARTS DATA
INSERT INTO carts(custid) VALUES (1);
INSERT INTO carts(custid) VALUES (2);
INSERT INTO carts(custid) VALUES (3);
INSERT INTO carts(custid) VALUES (4);
INSERT INTO carts(custid) VALUES (5);




-- CARTS ITEMS DATA
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(1,1,20);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(2,2,40);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(2,2,40);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(3,4,10);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(3,4,50);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(3,2,260);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(4,3,200);
INSERT INTO cartitems(cartid,productid ,quantity) VALUES(4,3,201);


-- PAYMENTS DATA
INSERT INTO payments(date,mode,transactionid,userid,orderid) VALUES('2022-03-08 12:08:19','cash on delivery',1,1,1);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-03-08 12:08:19','online payment',2,4,1);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-03-08 12:08:19','cash on delivery',2,4,2);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-03-08 12:08:19','online payment',2,4,3);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-03-08 12:08:19','cash on delivery',3,2,4);
INSERT INTO payments(date,mode,transactionid,userid,orderid)  VALUES('2022-06-10 12:45:30','cash on delivery',3,2,2);


-- ADDRESS DATA
-- INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(1,'permanent','houseNo.32','akshara garden','pune','maharashtra','india','410503');
-- INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(1,'billing','houseNo.32','akshara dairy','pune','maharashtra','india','410502');
-- INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(2,'permanent','houseNo.32','season mall','pune','maharashtra','india','410504');
-- INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(3,'billing','houseNo.32','Peth-Kurwandi Road','Manchar','Maharashtra','India','410506');
-- INSERT INTO addresses(custid,addressmode,housenumber,landmark,city,state,country,pincode) VALUES(4,'permanent','houseNo.234','Pune-Nashik Highway','Rajgurunagar','Maharashtra','India','1213');

-- EMPLOYESS DATA
-- INSERT INTO seller(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('akash','ajab','1999-09-15','2022-05-12','/image/akash.jpg',2,2);
-- INSERT INTO seller(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('pragati','Bangar','2000-12-18','2022-05-12','/image/vedant.jpg',1,1);
-- INSERT INTO seller(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('anil','hinge','2023-09-15','2022-06-14','/image/sahil.jpg',2,10);
-- INSERT INTO seller(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('rohan','amate','2015-09-15','2022-07-13','/image/prakash.jpg',4,11);
-- INSERT INTO seller(firstname,lastname,birthdate,hiredate,photo,reportsto,userid) VALUES('ajay','lanke','1988-09-15','2022-08-11','/image/nilesh.jpg',1,12);


-- SHIPPERS DATA
INSERT INTO shippers(corporateid,userid) VALUES('agrotech pvt.ltd',13);
INSERT INTO shippers(companyname,userid) VALUES('agrilens pvt.ltd',14);
INSERT INTO shippers(companyname,userid) VALUES('croproot pvt.ltd',15);
INSERT INTO shippers(companyname,userid) VALUES('greenery pvt.ltd',16);

--shipments 
 shipperordermapper -
 shipperid orderid 



-- SUPPLIERS DATA
-- INSERT INTO suppliers(companyname,suppliername,address,city,state,userid) VALUES('kaveri','abhishek bhor','pimpalgaon','pune','maharashtra',17);
-- INSERT INTO suppliers(companyname,suppliername,address,city,state,userid) VALUES('kalash seeds','pratik wagh','khadaki','pune','maharashtra',18);
-- INSERT INTO suppliers(companyname,suppliername,address,city,state,userid) VALUES('greenary','datta dhoble','manchar','pune','maharashtra',19);
-- INSERT INTO suppliers(companyname,suppliername,address,city,state,userid) VALUES('kavya','kavya bangar','chandoli','pune','maharashtra',20);

-- USER ROLES DATA

-- FEEDBACKS DATA
INSERT INTO feedbacks(description,custid) VALUES ('very good facilitities',1);
INSERT INTO feedbacks(description,custid) VALUES ('good quality of products',2);
INSERT INTO feedbacks(description,custid) VALUES ('very good for farmers ',3);
INSERT INTO feedbacks(description,custid) VALUES ('farmers are protected from frauds',4);

INSERT INTO questioncategories(category) VALUES('crop related questions');
INSERT INTO questioncategories(category) VALUES('soil related questions');
INSERT INTO questioncategories(category) VALUES('weather releted questions');


-- QUESTION TABLE DATA

INSERT INTO questions(description,categoryid,custid,questiondate) VALUES('How can I increase crop yield?',1);
INSERT INTO questions(description,categoryid) VALUES('How can I prevent crop damage from pests and diseases?',1);
INSERT INTO questions(description,categoryid) VALUES('How can I improve soil fertility? ',2);
INSERT INTO questions(description,categoryid) VALUES('How can I improve soil structure? ',2);
INSERT INTO questions(description,categoryid)VALUES('How can I prevent soil erosion? ',2);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is a drought?',3);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is heavy rainfall? ',3);
INSERT INTO questions(description,categoryid) VALUES('What should I do if there is extreme heat?',3);

-- CUSTOMERQUESTIONS TABLE DATA
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (1,1,'2022-01-15');
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (2,2,'2023-02-15');
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (2,4,'2023-01-15');
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (3,3,'2022-05-15');
INSERT INTO customerquestions(custid,questionid,questiondate) VALUES (4,2,'2022-08-15');

-- SME TABLE DATA
INSERT INTO subjectmatterexperts(name,expertise,userid) VALUES('pratima patil','crop related information',22);
INSERT INTO subjectmatterexperts(name,expertise,userid) VALUES('kiran rakshe','soil related information',23);
INSERT INTO subjectmatterexperts(name,expertise,userid) VALUES('mayur gorade','Weather related information',24);



-- ANSWERS TABLE DATA

INSERT INTO answers(description,questionid) VALUES('Soil health: Ensure the soil is healthy by adding organic matter and nutrients, improving drainage and water retention, and avoiding soil erosion.',1);
INSERT INTO answers(description,questionid) VALUES('Monitor crops regularly for signs of pests and diseases and take appropriate measures to prevent and control them.
                                          Use resistant crop varieties.',1);
INSERT INTO answers(description,questionid)VALUES('Consider local weather patterns and the plants growth requirements.',2);
INSERT INTO answers(description,questionid) VALUES('Soil testing: Perform soil tests to determine nutrient deficiencies and pH levels.
                                           Fertilizer: Apply appropriate amounts of fertilizers to address nutrient deficiencies.',2);
INSERT INTO answers(description,questionid) VALUES('Reduce soil compaction: Avoid excessive tillage, limit heavy machinery use, and avoid working on wet soil.',2);
INSERT INTO answers(description,questionid) VALUES('Cover crops: Plant cover crops to help prevent soil erosion by reducing runoff and increasing soil structure.',3);
INSERT INTO answers(description,questionid) VALUES('Irrigation: Use irrigation techniques to provide plants with the necessary water.
                                          Crop selection: Choose crops that are drought-tolerant.',3);
INSERT INTO answers(description,questionid) VALUES('Soil erosion prevention: Implement soil erosion prevention practices, such as planting cover crops, to help protect soil from being washed away.
										  Crop selection: Choose crops that are better suited to wet conditions.',3);


-- SME ANSWERS
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (1,1,'2023-04-05 12:08:06',1);
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (1,1,'2023-06-05 12:20:19',1);
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (2,1,'2023-07-10 12:23:08',2);
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (2,1,'2023-08-25 12:34:20',2);
INSERT INTO smeanswers(answerid,questionid,answerdate,smeid) VALUES (3,1,'2023-09-15 12:40:30',3);





-- BILING TABLE DATA

-- INSERT INTO billing(custid,orderid,Total,date) VALUES (2,1,1000,'2022-02-12 00:00:00');
-- INSERT INTO billing(custid,orderid,Total,date) VALUES (3,2,400,'2022-02-12 00:00:00');
-- INSERT INTO billing(custid,orderid,Total,date) VALUES (1,3,1200,'2022-02-12 00:00:00');
