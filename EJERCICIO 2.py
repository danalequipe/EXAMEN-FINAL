# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""


import pyodbc
conn = pyodbc.connect('Driver={ODBC Driver 17 for SQL Server};'
                      'Server=DESKTOP-JJMELD8;'
                      'Database=examen;'
                      'UID=sa;''PWD=1234567')
cursor = conn.cursor();
cursor.execute('select * from estudiante')

for row in cursor:
    print(row)
            