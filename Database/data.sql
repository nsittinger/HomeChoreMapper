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

COMMIT;