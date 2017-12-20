-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN;

-- INSERT statements go here

INSERT INTO chores VALUES ('General Tidy', 'As Needed', 'Clean up random things so home looks nice', 0);
INSERT INTO chores VALUES ('Load Dishwasher', 'As Needed', 'Clean dishes in sink and place in dishwasher', 0);
INSERT INTO chores VALUES ('Run Dishwasher', 'As Needed', 'Run machine', 0);
INSERT INTO chores VALUES ('Unload Dishwasher', 'As Needed', 'Remove dishes from dishwasher and put in correct place', 0);
INSERT INTO chores VALUES ('Kitchen Counters', 'Daily', 'Wipe off kitchen counters', 0);
INSERT INTO chores VALUES ('Make Bed', 'Daily', null, 0);
INSERT INTO chores VALUES ('Vacuum', 'Weekly', null, 0);
INSERT INTO chores VALUES ('Dust', 'Weekly', 'Dust around home (must move objects)', 0);
INSERT INTO chores VALUES ('Master Bathroom', 'Weekly', 'General tidiness of bathroom', 0);
INSERT INTO chores VALUES ('Guest Bathroom', 'Weekly', 'General tidiness of bathroom', 0);
INSERT INTO chores VALUES ('Garbage - Kitchen', 'Weekly', null, 0);
INSERT INTO chores VALUES ('Garbage - Bathroom', 'Weekly', null, 0);
INSERT INTO chores VALUES ('Recycling', 'Weekly', null, 0);
INSERT INTO chores VALUES ('Master Bedroom', 'Weekly', 'General tidiness of master bedroom', 0);
INSERT INTO chores VALUES ('Guest Bedroom', 'Weekly', 'General tidiness of guest bedroom', 0);
INSERT INTO chores VALUES ('Master Shower', 'Monthly', null, 0);
INSERT INTO chores VALUES ('Guest Shower', 'Monthly', null, 0);
INSERT INTO chores VALUES ('Refrigerator', 'Monthly', 'Clean out old food', 0);
INSERT INTO chores VALUES ('Bed Sheets', 'Monthly', 'Wash bed sheets', 0);

INSERT INTO homes_users_chores VALUES(112, 1, 'Rocky''s Crib', 1, 'RockyTop', 2, 'Load Dishwasher', '2017/12/13', 'meow')
INSERT INTO homes_users_chores VALUES(113, 1, 'Rocky''s Crib', 1, 'RockyTop', 3, 'Run Dishwasher', '2017/12/13', 'meow')
INSERT INTO homes_users_chores VALUES(114, 1, 'Rocky''s Crib', 1, 'RockyTop', 4, 'Unload Dishwasher', '2017/12/13', 'meow')
INSERT INTO homes_users_chores VALUES(125, 1, 'Rocky''s Crib', 2, 'Claire', 5, 'Kitchen Counters', '2017/12/13', 'all clean!')
INSERT INTO homes_users_chores VALUES(1310, 1, 'Rocky''s Crib', 3, 'Nick14', 10, 'Guest Bathroom', '2017/12/13', 'all clean!')
INSERT INTO homes_users_chores VALUES(139, 1, 'Rocky''s Crib', 3, 'Nick14', 9, 'Master Bathroom', '2017/12/13', 'meow')

COMMIT;