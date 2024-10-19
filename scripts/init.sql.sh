#!/bin/bash

# inicia mss en segundo plano
/opt/mssql/bin/sqlservr &

# espera mss esté corriendo
sleep 30

# ejecución sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'MSS-fernando-123' -i /usr/src/app/createdatabase.sql

# mantiene el contenedor en ejecución
wait