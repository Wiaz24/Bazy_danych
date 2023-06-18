import yfinance as yf
import pandas as pd
import sys


# Pobierz argumenty przekazane do skryptu       kiedy get yearly data to nazwa, data start, false. kiedy daily to data dzisiaj i false - da ostatni wpis
#arguments = ["Tesla", "2023-06-15", True, True] #Company name, date, if hourly data, if only last data
arguments = sys.argv
start = str(arguments[1])
hourly_interval = arguments[2]
only_last = arguments[3]
com_symbol="TSL"
start = "2023-06-15"
if hourly_interval:
    interval="1h"
else:
    interval="1d"

match arguments[0]:
    case "Apple":
        com_symbol = 'AAPL'
    case "Tesla":
        com_symbol = 'TSL'
    case "Adobe":
        com_symbol = 'ADBE'
    case "Meta Platforms":
        com_symbol = 'META'

df = yf.download(com_symbol, start = start, progress=False, interval=interval)
close_vals = df["Close"]



if only_last:
    return_val = close_vals[len(close_vals)-1]      #newest data
    print(return_val)
    #sys.stdout.write(str(return_val))
else:
    for line in close_vals:                         #all data
        print(line)
        #sys.stdout.write(str(line))


sys.stdout.flush()