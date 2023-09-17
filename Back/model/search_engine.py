from parser import Document


class Search:

    def get_search_request(self, request: str):
        raise NotImplementedError

    def search_in_db(self):
        raise NotImplementedError
        # return search result
