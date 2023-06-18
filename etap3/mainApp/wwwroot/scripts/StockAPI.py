import yfinance as yf
import pandas as pd
import sys


# Pobierz argumenty przekazane do skryptu       kiedy get yearly data to nazwa, data start, false. kiedy daily to data dzisiaj i false - da ostatni wpis
#arguments = ["Tesla", "2023-06-15", True, True] #Company name, date, if hourly data, if only last data
arguments = sys.argv
#start = str(arguments[2])
hourly_interval = arguments[3]
only_last = arguments[4]
name = str(arguments[1]).strip()  # Strip the whitespace from the company name
start="2023-06-15"
if hourly_interval:
    interval = "1h"
else:
    interval = "1d"

com_symbol = ""
if name == "Apple":
    com_symbol = "AAPL"
elif name == "Tesla":
    com_symbol = "TSL"
elif name == "Adobe":
    com_symbol = "ADBE"
elif name == "Meta Platforms":
    com_symbol = "META"
else:
    sys.stderr.write("Invalid company name")
    sys.exit(1)

if not com_symbol:
    sys.stderr.write("Invalid company name")
    sys.exit(1)


df = yf.download(com_symbol, start=start, progress=False, interval=interval)
close_vals = df["Close"]

if only_last:
    return_val = close_vals[len(close_vals) - 1]  # newest data
    sys.stdout.write(str(return_val))
else:
    for line in close_vals:  # all data
        sys.stdout.write(str(line))

sys.stdout.flush()