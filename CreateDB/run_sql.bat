echo off

rem batch file to run a sql script with sqlexpress

sqlcmd -S localhost -E -i create_tables.sql
sqlcmd -S localhost -E -i create_stored_procedures.sql
sqlcmd -S localhost -E -i insert_data.sql

sqlcmd -S localhost -E -i create_location_tables_and_stored_procedures.sql
sqlcmd -S localhost -E -i insert_locations.sql

echo .
echo If no error messages appear, the database should be properly created.
pause