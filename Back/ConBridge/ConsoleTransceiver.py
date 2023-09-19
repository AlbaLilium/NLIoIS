

class ConsoleTransceiver:
	"""
	(child process transceiver)
	Takes over stdin and stdout to reply to requests in a standardized manner.
	A way to achieve inter-process communication, with this being in a child process.
	This method is very hacky. Be cautious for serious projects and consider other approaches.
	"""

	def __init__(self):
		pass

	def take_over_until_exit(self):
		"""
		Takes over stdin and stdout until an exit command is received.
		Does not block the streams but assumes exclusive rights. 
		"""
		while True:
			received = input()
			if received == "exit":
				#TODO: Put command into some sort of enum
				break
			else:
				self._handle_received(received)

	def _handle_received(self, received: str):
		#TODO
		pass
	
	def _transmit_raw(self, response: str):
		"""Transmits a raw string. May not contain new lines."""
		if "\n" in response or "\r" in response:
			raise ValueError("Raw response string may not contain new lines")
		print(response, flush=True)
