# https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/elixir

def snail([]), do: []
  def snail(matrix) do
    {queue_elements, new_queue_matrix} = queue(matrix)

    {last_elements, last_elements_matrix} = last_elements(new_queue_matrix)

    {stack_elements, stack_matrix} = stack(last_elements_matrix)

    {first_elements, first_elements_matrix} = first_elements(stack_matrix)

    queue_elements ++ last_elements ++ stack_elements ++ first_elements ++ snail(first_elements_matrix)
  end

  def last_elements([]), do: {[], []}
  def last_elements([row | matrix_tail]) do
    {last, new_array} = List.pop_at(row, -1)

    { last_array, new_matrix_tail } = last_elements(matrix_tail)

    {[last] ++ last_array, [new_array] ++ new_matrix_tail}
  end

  def first_elements([]), do: {[], []}
  def first_elements([row | matrix_tail]) do
    {first, new_array} = List.pop_at(row, 0)

    {firsts_array, new_matrix_tail} = first_elements(matrix_tail)

    {firsts_array ++ [first], [new_array] ++ new_matrix_tail}
  end

  def queue([[]]), do: {[], []}
  def queue([]), do: {[], []}
  def queue([[_head | _tail] = first_line | matrix_tail]), do: { first_line, matrix_tail }

  def stack([]), do: {[], []}
  def stack(matrix) do
    {elements, new_matrix} = List.pop_at(matrix, -1)
    {Enum.reverse(elements), new_matrix}
  end
end


# A better way (It was not made by my):

defmodule Matrix do
  def horiz_reflect(m), do: m |> Enum.reverse
  def transpose(m),     do: m |> List.zip |> Enum.map(&Tuple.to_list(&1))
  def rotate(m),        do: m |> Matrix.transpose |> Matrix.horiz_reflect
end

defmodule Snail do
  def snail([]), do: []
  def snail( [h|t] ), do: h ++ (t |> Matrix.rotate |> snail)
end
