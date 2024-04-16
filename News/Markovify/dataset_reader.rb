require 'json'

class Dataset
	def self.load_from_json
		File.read('./fixtures/dataset.json')
	end

	def self.get_data
		data = JSON.parse(load_from_json)
    combined_text = ""
    data.each do |key, value|
    combined_text += value.join(" ")
    end
    combined_text.to_s
	end
  
end


