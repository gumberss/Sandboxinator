
#IO.puts Time.utc_now
t = ~T[19:39:31.052321]
IO.puts t
t.hour
t.minute

IO.puts Date.utc_today
{:ok, date} = Date.new(2020, 11, 04)

IO.puts Date.day_of_week date # Return which day of weak this date is
IO.puts Date.leap_year? date # Ano bisexto
#There is no support for timezone:
NaiveDateTime.utc_now
NaiveDateTime.add(~N[2018-10-01 00:00:14], 30) # Add 30 seconds
DateTime.from_naive(NaiveDateTime.utc_now, "Etc/UTC")



