import yfinance as yf
import pandas as pd
import sys

# Pobierz argumenty przekazane do skryptu
arguments = sys.argv
start = str(arguments[1])
df = yf.download('AAPL',start = start,progress=False)
print(df["Close"].iloc[0])