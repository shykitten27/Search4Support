
INSERT INTO categories
VALUES(1, "Counseling");
INSERT INTO categories
VALUES(2, "Food Support");
INSERT INTO categories
VALUES(3, "Housing");
INSERT INTO categories
VALUES(4, "LGBTQ Support");
INSERT INTO categories
VALUES(5, "Job Training");
INSERT INTO categories
VALUES(6, "Emergency Shelter");
INSERT INTO categories
VALUES(7, "Domestic Abuse Support");
INSERT INTO categories
VALUES(8, "After School Programs");
INSERT INTO categories
VALUES(9, "Child Care");
INSERT INTO categories
VALUES(10, "Healthcare");
INSERT INTO categories
VALUES(11, "Sexual Assault");
INSERT INTO categories
VALUES(12, "Substance Abuse");

INSERT INTO providers
VALUES (1, "Safe Connections", "314-646-7500", "2165 Hampton Ave, St. Louis, MO 63139", "", "Safe Connections’ award-winning, nationally-accredited programs reduce the impact and incidence of domestic and sexual violence through youth education, 24-hour crisis care, and therapy for adult and teen survivors.");
INSERT INTO providers
VALUES(2, "Ritenour School District", "314-493-6028", "9303 Midland Blvd, Overland, MO 63114", "", "Serving Overland and St. John");
INSERT INTO providers
VALUES(3, "Salvation Army", "314-423-7770", "10740 West Page Ave, St. Louis, MO 63132", "", "The Salvation Army, an international movement, is an evangelical part of the universal Christian Church. Its message is based on the Bible. Its ministry is motivated by the love of God. Its mission is to preach the gospel of Jesus Christ and to meet human needs in His name without discrimination.");
INSERT INTO providers
VALUES(4, "YWCA", "314-531-1115", " 1155 Olivette Executive Pkwy, St. Louis, MO 63132", "", "YWCA is dedicated to eliminating racism, empowering women, and promoting peace, justice, freedom and dignity for all.");
INSERT INTO providers
VALUES(5, "Food Outreach", "314-652-3663", "3117 Olive Street, St. Louis, MO 63103", "", "A MISSION OF NUTRITION DOING OUR PART IN THE FIGHT AGAINST HIV/AIDS AND CANCER");
INSERT INTO providers
VALUES(6, "NAMI St. Louis", "314-962-4670", "1810 Craig Rd, Ste 124, St. Louis, MO 63146", "", "NAMI St. Louis is an organization of families, friends and individuals whose lives have been affected by mental illness. Together, we advocate for better lives for those individuals who have a mental illness, and we offer support, education and advocacy as we do so.");
INSERT INTO providers
VALUES(7, "Planned Parenthood - Central West End Health Center", "314-531-7526", "4251 Forest Park Ave, St. Louis, MO 63108", "", "Operated by Planned Parenthood of the St. Louis Region and Southwest Missouri");
INSERT INTO providers
VALUES(8, "Planned Parenthood - South Grand Health Center", "314-865-1580", "3401 South Grand, St. Louis, MO 63118", "","Operated by Planned Parenthood of the St. Louis Region and Southwest Missouri");

INSERT INTO services
VALUES(1, "Individual Therapy", "Licensed counselors and licensed social workers provide emotional and psychological support through Individual Therapy to help victims rebuild their lives as survivors.", 1, 1);
INSERT INTO services
VALUES(2, "Ritenour Co-Care Food Pantry", "Our mission is to provide relief from the toxic stress of food insecurity in a respectful and dignified manner to anyone living within the Ritenour school district.", 2, 2);
INSERT INTO services
VALUES(3, "DBT-Informed Skills Group", "Thursdays, 6-7:00 p.m.
Learn skills to increase mindfulness, tolerate distress, regulate emotions and become more effective in relationships in this group. This group uses five 6-week modules. Participants are required to have an individual therapist (can be an outside therapist or Safe Connections therapist). Some parent/guardian participation is required.
Teen groups take place either at our Hampton office or virtually with telehealth.", 1, 1);
INSERT INTO services
VALUES(4, "Basics Support Group", "NAMI Basics Support Group is a peer-led support group for parents, caregivers, and other family who provide care for youth (ages 22 and younger) who are experiencing symptoms of a mental health condition. Gain insight from the challenges and successes of others facing similar experiences.", 6, 1);
INSERT into services
VALUES (5, "Family Support Group", "NAMI Family Support Group is a peer-led support group for any adult with a loved one who has experienced symptoms of a mental health condition. Gain insight from the challenges and successes of others facing similar experiences.", 6, 1);
INSERT INTO services
VALUES(6, "Peer-to-Peer", "NAMI Peer-to-Peer is a free, eight-session educational program for adults with mental health conditions who are looking to better understand themselves and their recovery.
Taught by trained leaders with lived experience, this program includes activities, discussions and informative videos. However, as with all NAMI programs, it does not include recommendations for treatment approaches.", 6, 1);
INSERT INTO services
VALUES(7, "Women's Resource Center", "YWCA Metro St. Louis Women’s Resource Center assists more than 1,000 victims annually. Its domestic violence-sexual assault response team works collaboratively with St. Louis City and County police officers, area hospitals, and prosecutors as well as with other victim service agencies. Crisis services are provided at no cost to victims.", 4, 11);
INSERT INTO services
VALUES(8, "Head Start and Early Head Start", "Head Start and Early Head Start are federally and state-funded programs that provide high-quality education, child care, and family support to income-eligible families.", 4, 9);
INSERT INTO services
VALUES(9, "Rapid Re-housing", "Rapid Re-Housing for homeless women and families seeking safety from domestic violence, sexual assault or stalking is available during COVID-19. Call (314) 726-6665.", 4, 7);
INSERT INTO services
VALUES(10, "Nutrition Counseling", "NUTRITION EXPERTISE FOR EACH CLIENT'S UNIQUE SET OF CIRCUMSTANCES", 5, 2);
INSERT INTO services
VALUES(11, "Meal Delivery", "Because some clients are too weak or ill to pick up their food orders from Food Outreach, our part-time van driver delivers up to 60 meals (two meals per day) every month to each homebound client through our Meal Delivery Program.", 5, 2);
INSERT INTO services
VALUES(12, "Meals and Groceries", "THANKS TO OUR INCREDIBLE SUPPORTERS, OUR MEALS ARE HAND-PREPARED AND OUR SHELVES ARE ALWAYS STOCKED", 5, 2);
INSERT INTO services
VALUES(13, "Reproductive Health Services of PPSLR", "Services Offered: Abortion, Birth Control, Emergency Contraception", 7, 10);
INSERT INTO services
VALUES(14, "Health Center", "Services offered: Birth Control, HIV Services, LBGTQ services, Men's Health Care, Emergency Contraception, Pregnancy Testing and Services, STD Testing, Treatment, and Vaccines, Women's Health Care", 8, 10);
INSERT INTO services
VALUES(15, "LGBTQ Support", "Homeless Shelters, Help with Substance Abuse, Food Insecurity, Teenage Suicide, Job Training", 3, 4);
INSERT INTO services
VALUES(16, "Alcohol and Drug Rehab", "Combat addiction, Build work and social skills, Regain health and stability, Restore families", 3, 12);

INSERT INTO tags
VALUES(1, "Adults");
INSERT INTO tags
VALUES(2, "Teens");
INSERT INTO tags
VALUES(3, "Children");
INSERT INTO tags
VALUES(4, "Early Childhood");
INSERT INTO tags
VALUES(5, "No-cost");
INSERT INTO tags
VALUES(6, "Sliding scale pricing");
INSERT INTO tags
VALUES(7, "volunteer");
INSERT INTO tags
VALUES(8, "Faith-based");
INSERT INTO tags
VALUES(9, "Family");
INSERT INTO tags
VALUES(10, "Education");
INSERT INTO tags
VALUES(11, "Virtual");
INSERT INTO tags
VALUES(12, "COVID Vaccine Required");
INSERT INTO tags
VALUES(13, "Mask required");
INSERT INTO tags
VALUES(14, "Women");
INSERT INTO tags
VALUES(15, "Men");
INSERT INTO tags
VALUES(16, "Non-binary");
INSERT INTO tags
VALUES(17, "LGBTQ");
INSERT INTO tags
VALUES(18, "Trauma");
INSERT INTO tags
VALUES(19, "Event");
INSERT INTO tags
VALUES(20, "Class");




