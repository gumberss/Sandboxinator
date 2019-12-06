defmodule Day5Test do
  use ExUnit.Case
  doctest Day5

  test "greets the world" do
    assert Day5.hello() == :world
  end

  test "Should fail" do
    #assert Day5.hello() == :fail
    refute Day5.hello() == :fail
  end

  test "Should receive ping" do
    Day5.run(self())
    assert_received :ping
  end

  #Capture output
  import ExUnit.CaptureIO
  #Capture Log
  import ExUnit.CaptureLog
  require Logger

  test "Output Batman is a hero" do
    assert capture_io(fn -> IO.puts "Batman is a hero" end) == "Batman is a hero\n"
    # =~ operator means contains. Example:
    #"Batman" =~ "Bat" == true
    #"Hero" =~ "sugar" == false
    #So, log data is something like \n22:05:08.042 [info] Thanos is comming\n
    #and I'd like only know if the log logged the sentence "Thanos is comming", so I'm using "=~" operator
    assert capture_log(fn -> Logger.info("Thanos is comming") end) =~ "Thanos"
  end

end
